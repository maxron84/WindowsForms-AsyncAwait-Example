﻿using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// .NET Framework 4.7.2 (Legacy but should run fine on any Windowsmachine)
/// C# WinForms Application to demonstrate approach for keeping the Frontend responsive while executing longterm'ish stuff in the background.
/// The background stuff reports it's progress to be visible to the user. I tried to keep the example as simple as possible.
/// </summary>
namespace WinForms_AsyncOps_Example
{
    /// <summary>
    /// Standard WinForms Form-Class with WinForms Designer Support (The control drag & drop thing)
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructor of this Class loading WinForms Designer Support
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Eventhandling Method for Buttonclick event (There is only one Button in this Form). This method is autogenerated by the designer.
        /// All you need to do is calling methods or fire further events. In this case we just call/start the Running Task.
        /// </summary>
        /// <param name="sender">The Button</param>
        /// <param name="e">Standard EventArgs, nothing to worry about</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            _ = LongRunningAsync();
        }

        /// <summary>
        /// Executes the LongRunning Task and manipulates the Controls of the Form (non atomic method).
        /// </summary>
        /// <returns>A Task which is OK to be just discarded in the calling method as long as everything runs fine.</returns>
        private async Task LongRunningAsync()
        {
            if (Regex.IsMatch(txtInput.Text, @"^[0-9]+$"))
            {
                btnGo.Enabled = false;
                txtInput.Enabled = false;

                long steps = long.Parse(txtInput.Text);

                lblStatus.Text = "Running...";

                try
                {
                    double result = await DoLongRunningWithProgressReporting(steps, new Progress<long>(totalSteps =>
                    {
                        lblSteps.Text = "Total steps: " + totalSteps.ToString();
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Instead of throwing just print the error in a popup box (Not tested if generic Exception fits)
                }

                lblStatus.Text = "Run done!";
                btnGo.Text = "Dewit again";

                btnGo.Enabled = true;
                txtInput.Enabled = true;
            }
            else
            {
                lblStatus.Text = "Check your input!";
            }
        }

        /// <summary>
        /// This guy does the actual work (non atomic method).
        /// Progress is being reported to control. The reporting procedure is not perfect, but it works.
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="progress"></param>
        /// <returns>The total value after LongRunningTask ist finished. </returns>
        private Task<double> DoLongRunningWithProgressReporting(long steps, IProgress<long> progress)
        {
            return Task.Run(() =>
            {
                double total = 0;

                for (long i = 1; i < steps + 1; i++)
                {
                    total++;

                    // Statusrückgabe nach jedem Schritt, reaktiv bleibt die Anwendung jedoch in diesem Falle nur mit...
                    // Statusreport for every step, the application will block while running...
                    Thread.Sleep(1); // ...künstlicher Ausbremsung der CPU-Leistung // ... if you don't put sleep intervalls for every step...
                    if (progress != null)
                        progress.Report(i);
                }

                return total;
            });
        }
    }
}
