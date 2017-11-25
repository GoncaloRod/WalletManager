﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace WalletManager
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            /* NOT WORKING!!!
            // CHeck if DB path is created
            if (!Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WalletManager")) Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WalletManager");
            // Check if DB is created
            if (!File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WalletManager\WalletManager.mdf")) DB.Instance.CreateFromFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WalletManager\WalletManager.mdf", @".\..\..\create_tables.sql");
            */
        }

        private void btnLoginClick(object sender, RoutedEventArgs e)
        {
            // Set up variables for to execute SQL command
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            // Validate form
            // Do things

            if (Session.Instance.Attempt(email, password))
            {
                // Load user window
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // Tell user that creedentials are incorect
                MessageBox.Show("Email and password does not match!");          // TODO: Custom message window
            }
        }

        private void btnRegisterClick(object sender, RoutedEventArgs e)
        {
            // Show register window
            Register windowRegister = new Register();
            windowRegister.ShowDialog();

            // Check if registration was completed with success
            if ((bool)windowRegister.DialogResult)
            {
                // Tell user that account was created with success
                MessageBox.Show("Account created with success!");               // TODO: Custom message window
            }
        }
    }
}
