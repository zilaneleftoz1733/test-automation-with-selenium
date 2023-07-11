using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        // WebDriver'ı başlat
        IWebDriver driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe");

        // N11'in ana sayfasını aç
        driver.Navigate().GoToUrl("https://www.n11.com/");

        // sayfayı genişletme
        driver.Manage().Window.Maximize();
        Thread.Sleep(2000);
        //giriş yap ekranı
        driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div[5]/div/div/div/a[2]")).Click();
        Thread.Sleep(2000);

        driver.FindElement(By.Id("email")).SendKeys("lzilaneleftozl@gmail.com");
        Thread.Sleep(2000);

        driver.FindElement(By.Id("password")).SendKeys("Zilan1733.");
        Thread.Sleep(2000);

        //sayfayı ortalama
        // JavaScriptExecutor örneği al
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        // Sayfayı yatay yönde scroll etmek için JavaScript kodunu çalıştır
        js.ExecuteScript("window.scrollBy(0, 500);");

        // Sayfayı dikey yönde scroll etmek için JavaScript kodunu çalıştır
        js.ExecuteScript("window.scrollBy(0, 500);");

        driver.FindElement(By.XPath("//*[@id=\"loginButton\"]")).Click();
        Thread.Sleep(2000);

        // Arama kutusuna bir ürün adı girin
        IWebElement searchBox = driver.FindElement(By.Id("searchData"));
        searchBox.SendKeys("Poco X5 Pro 5G 8 GB 256 GB"); // İstediğiniz ürün adını buraya girin
        searchBox.SendKeys(Keys.Return);

        
        Thread.Sleep(5000);
        IReadOnlyCollection<IWebElement> productResults = driver.FindElements(By.CssSelector(".result.searchData"));

        // İstediğiniz ürünün listede olup olmadığını kontrol et
        bool isProductExist = productResults.Any(result => result.Text.Contains("Poco X5 Pro 5G 8 GB 256 GB"));
        if (isProductExist)
        {
            Console.WriteLine("Ürün bulundu.");
        }
        else
        {
            Console.WriteLine("Ürün bulunamadı.");
        }

        // sayfayı ortalama 
        // JavaScriptExecutor örneği al
        IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;

        // Sayfayı yatay yönde scroll etmek için JavaScript kodunu çalıştır
        js1.ExecuteScript("window.scrollBy(0, 150);");

        // Sayfayı dikey yönde scroll etmek için JavaScript kodunu çalıştır
        js1.ExecuteScript("window.scrollBy(0, 150);");

        // sepete ekle 
        IWebElement btnBasket = driver.FindElement(By.CssSelector("#p-569601988 > div > span"));
        btnBasket.Click();
        Thread.Sleep(2000);



        bool IsElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        void AddToBasket()
        {
            By colorLocator = By.CssSelector("#skus-804457216 > label:nth-child(2)");
            By memoryLocator = By.CssSelector("#skus-804457215 > label");

            if (IsElementPresent(colorLocator) && IsElementPresent(memoryLocator))
            {
                IWebElement btnColor = driver.FindElement(colorLocator);
                btnColor.Click();
                Thread.Sleep(2000);

                IWebElement btnMemory = driver.FindElement(memoryLocator);
                btnMemory.Click();
                Thread.Sleep(2000);
            }
            else
            {
                return;
            }

            IWebElement btnBasket = driver.FindElement(By.CssSelector("#js-addBasketSku"));
            btnBasket.Click();
            Thread.Sleep(2000);
        }

        Console.WriteLine("Ürün speete atıldı...");

        // Sepete git
        driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div[4]/div/div/div[2]/a")).Click();
        Thread.Sleep(2000);

        // Sepetin toplam tutarını al
        string totalPrice = driver.FindElement(By.XPath("//*[@id=\"newCheckout\"]/div/div[1]/div[2]/div/div/section/div/div[6]/span[2]")).Text;

        Thread.Sleep(2000);
        //Sepetin toplam tutarını yazdır
        Console.WriteLine("Sepetin Toplam Tutarı: " + totalPrice);


        // Verileri dosyaya yazma işlemleri burada gerçekleşecek


        // Verileri dosyaya kaydetme
        string dosyaYolu = "C:\\Users\\lzila\\Desktop\\SeleniumProject\\data.txt";
        

        if (File.Exists(dosyaYolu))
        {
            Console.WriteLine("Dosya mevcut.");
            using (StreamWriter writer = new StreamWriter("C:\\Users\\lzila\\Desktop\\SeleniumProject\\data.txt"))
            {

                writer.WriteLine("Sepetin toplam tutarı: " + totalPrice);

                Thread.Sleep(2000);
            }
        }
        else

        {
            Console.WriteLine("Lütfen dosyayı oluşturun ve ardından devam etmek için bir tuşa basın.");
            Console.ReadKey();
        }

        // WebDriver'ı kapat
        driver.Quit();
     
    }
}




