using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketLeagueGui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void closeApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void closeApp_MouseEnter(object sender, EventArgs e)
        {
        }
        private void closeApp_MouseLeave(object sender, EventArgs e)
        {

        }

 

        private void rocketAuth_Click(object sender, EventArgs e)
        {

            String login = loginText.Text;

            String password = passText.Text;

            string url = "https://rocket-league.com/login";

            ChromeOptions option = new ChromeOptions();
            option.PageLoadStrategy = PageLoadStrategy.Eager;
            option.AddArgument("no-sandbox");

            option.AddArgument("disable-gpu");

            option.AddArgument("--incognito");

            option.AddArgument("ignore-certificate-errors");

            option.AddArgument("--headless");

            option.AddArgument("start-maximized");

            option.AddArgument("--log-level=3");

            option.AddArgument("--disable-logging");

            option.AddUserProfilePreference("profile.default_content_setting_values.images", 2);// выключает фотки для быстрой загрузки

            ChromeDriver driver = new ChromeDriver(option);

            driver.Navigate().GoToUrl(url);

            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            driver.FindElement(By.XPath("//*[@id='acceptPrivacyPolicy']")).Click(); // принимает полиси про приватность




            IWebElement findLogin = waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/main/main/section/div/div/div[1]/form/input[2]")));

            findLogin.SendKeys(login);//login send login



            IWebElement findPassword = waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/main/main/section/div/div/div[1]/form/input[3]"))); // user pass field

            findPassword.SendKeys(password);//user send pass

  



            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/main/main/section/div/div/div[1]/form/input[4]"))).Click();// войти 

            Console.Clear();
            Console.WriteLine("Account Accessed", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;
            string url2 = "https://rocket-league.com/trades/";

            driver.Navigate().GoToUrl(url2);




            string src = driver.FindElement(By.XPath("/html/body")).GetAttribute("outerHTML").ToString();
            Regex regex = new Regex("(?<=href=\")(.*)(?=\" class)", RegexOptions.IgnoreCase);
            Match match;


            int xi = 0;

            string userRefresh = textBox1.Text;
            for (match = regex.Match(src); match.Success; match = match.NextMatch())
            {
                if (match.Value.Contains("/trade/edit?"))
                {
                    string DirtyEdit = match.Value.Replace("href=\"", "");
                    string EditLink = DirtyEdit.Replace("\" class", "");
                    string tradeLink = ("https://rocket-league.com" + EditLink);
                    Thread.Sleep(6000);
                    driver.Navigate().GoToUrl(tradeLink);

                    try
                    {


                        xi++;
                        IWebElement button = driver.FindElement(By.XPath("//*[@id='rlg-addTradeForm']/div[2]/button"));
                        button.Click();
                        Console.WriteLine("========================================================================", Console.ForegroundColor = ConsoleColor.Yellow);
                        Console.WriteLine("Trade Number:" + '[' + xi + ']' + " was BUMPED", Console.ForegroundColor = ConsoleColor.Green);
                        Console.ForegroundColor = ConsoleColor.White;
                        Random randomTimeout = new Random();
                        int timeout = randomTimeout.Next(30000);
                        int sumTimeTimeout = 30000 + timeout;
                        if (userRefresh == "")
                        {
                            Console.WriteLine("Wait [" + sumTimeTimeout + ']' + "ms", Console.ForegroundColor = ConsoleColor.Yellow);
                            Console.WriteLine("========================================================================", Console.ForegroundColor = ConsoleColor.Yellow);
                            Console.ForegroundColor = ConsoleColor.White;
                            int sumTimeInt = Convert.ToInt32(sumTimeTimeout);
                            Thread.Sleep(sumTimeInt);
                        }
                        else
                        {

                            Console.WriteLine("Wait [" + Convert.ToInt32(userRefresh) + ']' + "ms", Console.ForegroundColor = ConsoleColor.Yellow);
                            Console.WriteLine("========================================================================", Console.ForegroundColor = ConsoleColor.Yellow);
                            Console.ForegroundColor = ConsoleColor.White;
                            int sumTimeInt = Convert.ToInt32(sumTimeTimeout);
                            Thread.Sleep(Convert.ToInt32(userRefresh));
                        }


                    }
                    catch (OpenQA.Selenium.NoSuchElementException ex)
                    {
                        Console.Clear();
                        Console.WriteLine("Trade Number:" + '[' + xi + ']' + " has 15 min cooldown", Console.ForegroundColor = ConsoleColor.Red);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Trade AutoBump Completed!!", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Press the \"start\" button after ~ 15 minutes when the trades have a cooldown", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1080000);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ArslanAlimov");
        }
        Point lastPoint;
        private void MainForm_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
