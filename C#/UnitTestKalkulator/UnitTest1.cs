// memanggil kelas kalkulator
using MyCalculatorv1;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestKalkulator
{
    /*
   Unit Test Kalkulator adalah Unit Test yang didalamnya ada potongan kode program
     * yang akan ditest sesuai dengan fungsionlitas yang diharapkan
     * 
     * 
     * 6306110013 --> MOCH BAMBANG SULISTIO
     */

    [TestClass]
    public class UnitTestKalkulator
    {
       
        /*
         * Test untuk Fungsi Tambah Angka
         */ 
        [TestMethod]
        public void UTAddTest()
        {
            var test_object = new MainWindow();
            double expected = 999;
            double actual = test_object.Add(900, 99);
            Assert.AreEqual<double>(expected, actual, "Jawaban Tidak Sesuai ");
        }

        /*
         * Test untuk Fungsi Substract
         */ 
        [TestMethod]
        public void UTSubstractTest()
        {
            var test_object = new MainWindow();
            double expected = 10.5;
            double actual = test_object.Substract(15, 0.5);
            Assert.AreEqual<double>(expected, actual, "Jawaban Tidak Sesuai");
        }

        /*
         * Test untuk Fungsi Perkalian
         */ 
        [TestMethod]
        public void UTMultiplyTest()
        {
            var test_object = new MainWindow();
            double expected = 20;
            double actual = test_object.Multiply(10, 2);
            Assert.AreEqual<double>(expected, actual, "Jawaban Tidak Sesuai");
        }

        /*
         * Misal akan dilakukan pencet tombol 7, seharusnya output keluar 7
         */
        [TestMethod]
        public void UTButton_Click_1Test()
        {
            MainWindow window = new MainWindow();
            window.Show();
            WindowAutomationPeer windowPeer = new WindowAutomationPeer(window);
            List<AutomationPeer> children = windowPeer.GetChildren();

            ButtonAutomationPeer buttonPeer = (ButtonAutomationPeer)children[0];
            Button button = (Button)buttonPeer.Owner;
            RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent, button);
            button.RaiseEvent(args);
            Assert.AreEqual("7", button.Content.ToString(), button.Content.ToString());
        }
        /*
         * jika diklik tombol = seharusnya outputnya -1
         * 
         */
        [TestMethod]
        public void UTResult_clickTest()
        {
            string temporary = "0-1";

            MainWindow window = new MainWindow();
            window.Show();
            WindowAutomationPeer windowPeer = new WindowAutomationPeer(window);
            List<AutomationPeer> children = windowPeer.GetChildren();

            TextBoxAutomationPeer textBoxPeer = (TextBoxAutomationPeer)children[1];
            ButtonAutomationPeer buttonPeer = (ButtonAutomationPeer)children[14];

            Button button = (Button)buttonPeer.Owner;
            TextBox tb = (TextBox)textBoxPeer.Owner;

            tb.Text = temporary;

            RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent, button);
            button.RaiseEvent(args);

            Assert.AreEqual("0-1", tb.Text.ToString(), "Tidak Sesuai Output");
        }

        /*
         * Test jika klik tombol Del, maka tb akan ""  ?
         */
        [TestMethod]
        public void UTDel_ClickTest()
        {
            MainWindow window = new MainWindow();
            window.Show();
            WindowAutomationPeer windowPeer = new WindowAutomationPeer(window);
            List<AutomationPeer> children = windowPeer.GetChildren();

            TextBoxAutomationPeer textBoxPeer = (TextBoxAutomationPeer)children[1];
            ButtonAutomationPeer buttonPeer = (ButtonAutomationPeer)children[17];

            Button button = (Button)buttonPeer.Owner;
            TextBox tb = (TextBox)textBoxPeer.Owner;

            RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent, button);
            button.RaiseEvent(args);
            Assert.AreEqual("", tb.Text.ToString(), "Tidak dapat menjalankan fungsi dimaksud");
        }

        /*
        * Test jika klik tombol R, maka tb akan dihapus satu karakter terakhir  ?
        */
        [TestMethod]
        public void UTR_ClickTest()
        {
            MainWindow window = new MainWindow();
            window.Show();
            WindowAutomationPeer windowPeer = new WindowAutomationPeer(window);
            List<AutomationPeer> children = windowPeer.GetChildren();

            TextBoxAutomationPeer textBoxPeer = (TextBoxAutomationPeer)children[1];
            ButtonAutomationPeer buttonPeer = (ButtonAutomationPeer)children[18];

            Button button = (Button)buttonPeer.Owner;
            TextBox tb = (TextBox)textBoxPeer.Owner;


            RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent, button);
            button.RaiseEvent(args);

            int expected = 4;
            int actual = tb.Text.Length;

            Assert.AreEqual(expected, actual, "Output Program Tidak Sesuai");
        }
        /*
         * Test untuk Fungsi Pembagian
         */ 
        [TestMethod]
        public void UTDivideTest()
        {
            var test_object = new MainWindow();
            double expected = 10;
            double actual = test_object.Divide(20,2);
            Assert.AreEqual<double>(expected, actual, "Jawaban Tidak Sesuai ");
        }

      
    }
}
