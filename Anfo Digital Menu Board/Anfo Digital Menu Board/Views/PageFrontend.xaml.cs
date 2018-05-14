﻿using Anfo_Digital_Menu_Board.Dialog;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Anfo_Digital_Menu_Board.Views
{
    /// <summary>
    /// Interaction logic for PageFrontend.xaml
    /// </summary>
    public partial class PageFrontend : Page
    {
        public PageFrontend()
        {
            InitializeComponent();
        }
        koneksi k = new koneksi();

        private string _idktlog;

        private void btn_cari_Click(object sender, RoutedEventArgs e)
        {
            var showdialog = new DialogPilihKatalog();
            showdialog.Check += value => _idktlog = value;
            DialogHost.Show(showdialog, "MainDialog", ClosingEventHandler);
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            k.sql = "select *from tb_katalog where id_katalog = '" + _idktlog + "'";
            k.setdt();

            txt_idktlog.Text = k.dt.Rows[0][0].ToString();
            txt_deskripsi.Text = k.dt.Rows[0][1].ToString();
        }
    }
}
