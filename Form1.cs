﻿using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// .NET Framework 4.7.2 (Legacy but should run fine on any modern Windowsmachine)
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
        /// Executes the LongRunning Task in an asynchronous manner and manipulates the Controls of the Form (non atomic method).
        /// </summary>
        /// <returns>A Task which is OK to be just discarded in the calling method as long as everything runs fine.</returns>
        private async Task LongRunningAsync() // Marked async to tell the compiler we are awaiting something in this method
        {
            if (Regex.IsMatch(txtInput.Text, @"^[0-9]+$")) // Check if input is only digits using Regular Expression
            {
                btnGo.Enabled = false;
                txtInput.Enabled = false;

                long steps = long.Parse(txtInput.Text);

                lblStatus.Text = "Running...";

                try
                {
                    double result = await DoLongRunningWithProgressReporting(steps, new Progress<long>(totalSteps => // await the result asynchronously so app isn't blocked
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
        /// <param name="steps">How many steps do you want to run, determined by Textbox input (Standard: 100)</param>
        /// <param name="progress">The Progress object asking for reports to display progress to the user</param>
        /// <returns>The total value after LongRunningTask ist finished. </returns>
        private Task<double> DoLongRunningWithProgressReporting(long steps, IProgress<long> progress)
        {
            return Task.Run(() =>
            {
                double total = 0;

                for (long i = 1; i < steps + 1; i++)
                {
                    total++;

                    // Statusreport for every step, the application will block while running...
                    Thread.Sleep(1); //...if you don't put sleep intervalls to every step.
                    if (progress != null)
                        progress.Report(i);
                }

                return total;
            });
        }
    }
}
