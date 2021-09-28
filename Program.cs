using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using SautinSoft;
using System.IO.Compression;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Test(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            f.ToText("https://thebank.vn/vay-the-chap.html");
            Test test1 = new Test(1, "Cong");
            Test test2 = new Test(2, "Quang");
            Test test3 = new Test(1, "Khai");

            IEnumerable<Test> listTests;
            List<Test> lTests = new List<Test>();
            lTests.Add(test1);
            lTests.Add(test2);
            lTests.Add(test3);
            listTests = lTests;
            var result = listTests.Where(p => p.Id == 1);
            listTests.Take<Test>(2);

            foreach(var item in listTests.Take<Test>(2))
            {
                Console.WriteLine(item.Name);
            }

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Linux; Android 8.0.0; G3121) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.157 Mobile Safari/537.36");
            using (var response = await httpClient.GetAsync("https://thebank.vn/ajax/saveSitemapThebank"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                dynamic dynamicData = JsonConvert.DeserializeObject(apiResponse);

                for (int i = 0; i < dynamicData.types.Count; i++)
                {
                    Console.WriteLine(dynamicData.types[i].code);
                    Console.WriteLine(dynamicData.types[i].bankSell);
                    Console.WriteLine(dynamicData.types[i].bankBuy);
                    Console.WriteLine(dynamicData.types[i].bankBuyOD);
                }
            }

            
        }
    }
}

/*
  HttpClient httpClient = new HttpClient();
            using (var response = await httpClient.GetAsync("https://www.uob.com.vn/data-api-rates-vn/data-api/forex-vn?lang=en_VN"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                
                dynamic dynamicData = JsonConvert.DeserializeObject(apiResponse);

                for(int i = 0; i < dynamicData.types.Count; i++)
                {
                    Console.WriteLine(dynamicData.types[i].code);
                    Console.WriteLine(dynamicData.types[i].bankSell);
                    Console.WriteLine(dynamicData.types[i].bankBuy);
                    Console.WriteLine(dynamicData.types[i].bankBuyOD);
                }
            }

    
            //for (int i = 5; i < selection[1].ChildNodes.Count; i += 2)
            //{
            //    Console.WriteLine(selection[1].ChildNodes[i].ChildNodes[1].InnerText);
            //    Console.WriteLine(selection[1].ChildNodes[i].ChildNodes[3].InnerText);
            //    Console.WriteLine(selection[1].ChildNodes[i].ChildNodes[5].InnerText);
            //    Console.WriteLine("---------------------------------------");
            //}


=======================================================================
class Program
    {
        static async Task Main(string[] args)
        {
            //var httpClient = new HttpClient();
            //HttpResponseMessage responseMessage = await httpClient.GetAsync("https://portal.vietcombank.com.vn/Personal/lai-suat/Pages/lai-suat.aspx?devicechannel=default");
            //string htmlText = await responseMessage.Content.ReadAsStringAsync();
            //HtmlDocument doc = new HtmlDocument();
            //doc.LoadHtml(htmlText);
            //HtmlNode node = doc.DocumentNode.SelectNodes("//table[@id=\"danhsachlaisuat\"]").FirstOrDefault();
            //Console.WriteLine("" + node.SelectSingleNode("./th").InnerText);

            //Console.Write(htmlText);
            //await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
            //Browser browser = await Puppeteer.LaunchAsync(new LaunchOptions
            //{
            //    Headless = true
            //});
            //Page page = await browser.NewPageAsync();
            //await page.GoToAsync("https://portal.vietcombank.com.vn/Personal/lai-suat/Pages/lai-suat.aspx?devicechannel=default");
            //string content = await page.GetContentAsync();
            //Console.WriteLine("" + content);
            //HttpClient client = new HttpClient();
            //HtmlDocument doc = new HtmlDocument();
            //var response = await client.GetAsync(web);
            //if (!response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Lỗi");
            //}
            //var body = await response.Content.ReadAsStringAsync();
            //doc.LoadHtml(body);

            //SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            //f.OpenPdf("https://www.sc.com/global/av/vn-14-interest-rate-personal-banking-vn.pdf");
            //f.ToHtml("C:/Users/nxgth/OneDrive/Desktop/CTY/thebank.html");

            var url = "https://www.indovinabank.com.vn/vi/lookup/rates";
            HtmlWeb web = new HtmlWeb();
            //web.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; " + "Windows NT 5.2; .NET CLR 1.0.3705;)";
            var x = web.Load(url);

            var selection = x.DocumentNode.SelectNodes("//ul[@class='list-thumb-square dichvu tygia']");
            Console.WriteLine(selection[0].ChildNodes[0].SelectNodes("//div[@class='country-select']")[0].InnerText);
            Console.WriteLine(selection[0].ChildNodes[0].SelectNodes("//span[@class='red']")[0].InnerText);
            Console.WriteLine(selection[0].ChildNodes[0].SelectNodes("//span[@class='red']")[1].InnerText);
            Console.WriteLine(selection[0].ChildNodes[0].SelectNodes("//span[@class='red']")[2].InnerText);

            //for (int i = 1; i < 27; i += 2)
            //{
            //    Console.WriteLine(selection[4].ChildNodes[i].ChildNodes[1].InnerText.Trim());
            //    Console.WriteLine(selection[4].ChildNodes[i].ChildNodes[3].InnerText.Trim());
            //    Console.WriteLine(selection[4].ChildNodes[i].ChildNodes[5].InnerText.Trim());
            //    Console.WriteLine(selection[4].ChildNodes[i].ChildNodes[7].InnerText.Trim());
            //    Console.WriteLine("--------------------------------");
            //}


            //foreach (var value in selection)
            //{
            //    Names.Add(value.FirstChild.InnerText);
            //}

            //foreach (var value in Names)
            //{
            //    Console.WriteLine(value);
            //}

            //for (int i = 0; i < 15; i++)
            //{
            //    Console.WriteLine(selection[i].ChildNodes[1].ChildNodes[1].InnerText);
            //}

            //Console.WriteLine("Tien mat AUD: " + selection[12].InnerText.Trim());
            //Console.WriteLine("Tien mat CAD: - ");
            //Console.WriteLine("Tien mat CHF: - ");
            //Console.WriteLine("Tien mat DKK: - ");
            ////Console.WriteLine("Tien mat CNY: - ");
            //Console.WriteLine("Tien mat EUR: " + selection[9].InnerText.Trim());
            //Console.WriteLine("Tien mat GBP: " + selection[21].InnerText.Trim());
            //Console.WriteLine("Tien mat HKD: - ");
            //Console.WriteLine("Tien mat JPY: " + selection[27].InnerText.Trim());
            //Console.WriteLine("Tien mat SGD: " + selection[30].InnerText.Trim());
            //Console.WriteLine("Tien mat THB: - ");
            //Console.WriteLine("Tien mat USD 50 - 100: " + selection[0].InnerText.Trim());

            //Console.WriteLine("-------------------------------------------------------");

            //Console.WriteLine("CK AUD: " + selection[13].InnerText.Trim());
            //Console.WriteLine("CK CAD: " + selection[16].InnerText.Trim());
            //Console.WriteLine("CK CHF: " + selection[19].InnerText.Trim());
            //Console.WriteLine("CK DKK: " + selection[19].InnerText.Trim());
            ////Console.WriteLine("CK CNY: " + selection[40].InnerText.Trim());
            //Console.WriteLine("CK EUR: " + selection[10].InnerText.Trim());
            //Console.WriteLine("CK GBP: " + selection[22].InnerText.Trim());
            //Console.WriteLine("CK HKD: " + selection[25].InnerText.Trim());
            //Console.WriteLine("CK JPY: " + selection[28].InnerText.Trim());
            //Console.WriteLine("CK SDG: " + selection[31].InnerText.Trim());
            //Console.WriteLine("CK THB: " + selection[34].InnerText.Trim());
            //Console.WriteLine("CK USD: " + selection[1].InnerText.Trim());


            //Console.WriteLine("-------------------------------------------------------");

            //Console.WriteLine("Bán AUD: " + selection[14].InnerText.Trim());
            //Console.WriteLine("Bán CAD: " + selection[17].InnerText.Trim());
            //Console.WriteLine("Bán CHF: " + selection[20].InnerText.Trim());
            //Console.WriteLine("Bán DKK: " + selection[20].InnerText.Trim());
            ////Console.WriteLine("Bán CNY: " + selection[41].InnerText.Trim());
            //Console.WriteLine("Bán EUR: " + selection[11].InnerText.Trim());
            //Console.WriteLine("Bán GBP: " + selection[23].InnerText.Trim());
            //Console.WriteLine("Bán HKD: " + selection[26].InnerText.Trim());
            //Console.WriteLine("Bán JPY: " + selection[29].InnerText.Trim());
            //Console.WriteLine("Bán SGD: " + selection[32].InnerText.Trim());
            //Console.WriteLine("Bán THB: " + selection[35].InnerText.Trim());
            //Console.WriteLine("Bán USD: " + selection[2].InnerText.Trim());



            //Console.WriteLine("3thang" + selection[121].ChildNodes[0].InnerText);
            //Console.WriteLine("6thang" + selection[366].FirstChild.InnerText);
            //Console.WriteLine("9thang" + selection[232].LastChild.InnerText);
            //Console.WriteLine("12thang" + selection[246].LastChild.InnerText);
            //Console.WriteLine("13thang" + selection[260].LastChild.InnerText);
            //Console.WriteLine("18thang" + selection[274].LastChild.InnerText);

            //Console.WriteLine("24thang" + selection[1012].ChildNodes[0].InnerText);
            //Console.WriteLine("" + selection[616].ChildNodes[2].InnerText); //9thang
            //Console.WriteLine("" + selection[616].ChildNodes[2].InnerText); //12thang ---
            //Console.WriteLine("" + selection[616].ChildNodes[2].InnerText); //13thang
            //Console.WriteLine("" + selection[616].ChildNodes[2].InnerText); //18thang
            //Console.WriteLine("" + selection[616].ChildNodes[2].InnerText); //24thang
            //Console.WriteLine("" + selection[222].InnerText);
            //Console.WriteLine("" + selection[225].InnerText);
            //Console.WriteLine("" + selection[228].InnerText);
            //Console.WriteLine("" + selection[231].InnerText);
            //Console.WriteLine("" + selection[234].InnerText);
            ////Console.WriteLine("" + selection[235].InnerText.ddd);
            //Console.WriteLine("" + selection[236].InnerText);
            //Console.WriteLine("" + selection[237].InnerText);

            //var httpClient = new HttpClient();
            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            //httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
            //                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
            //using (var response = await httpClient.GetAsync("https://www.baovietbank.vn/AdTools/GetExChangeRate?dateTime="))
            //{
            //    string apiResponse = await response.Content.ReadAsStringAsync();
            //    //JObject x = JObject.Parse(apiResponse);

            //    //string JString = "{\"data\":{\"ChildNode\":\"true string\",\"Cates\":[1,2,3]}}";
            //    dynamic dynamicData = JsonConvert.DeserializeObject(apiResponse);
            //    //Console.WriteLine("" + dynamicData.hcm.data[0].VND);
            //    Console.WriteLine("MONEY CODE" + "      " + "TỶ GIÁ MUA" + "        " + "TỶ GIÁ MUA" + "      " + "TỶ GIÁ BÁN");
            //    foreach (var item in dynamicData)
            //    {
            //        Console.WriteLine(item.listEnq.currencY_CODE + "      " + item.listEnq.denomcasH_BUY_RATE + "     " + item.listEnq.denomtranS_BUY_RATE + "      " + item.listEnq.denomtranS_SELL_RATE);
            //    }
            //}

        }
    }
======================================
namespace JsonObjectConvert
{
    public class Kenno
    {
        public string Date { get; set; }
        public string Period { get; set; }

        public List<string> listNumber = new List<string>();
        public string MaxMin { get; set; }
        public string Parity { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://vietlott.vn/vi/trung-thuong/ket-qua-trung-thuong/winning-number-keno";
            //
            HtmlWeb web = new HtmlWeb();
            HttpClientHandler clientHandler = new HttpClientHandler();
            var client = new HttpClient();
            //var client = new HttpClient();
            HtmlDocument htmlDoc = new HtmlDocument();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Lỗi ");
            }
            var body = await response.Content.ReadAsStringAsync();
            htmlDoc.LoadHtml(body);
            var tables = htmlDoc.DocumentNode.SelectNodes("//table[@class='table table-hover']");
            var combine = tables[0].ChildNodes[1];
            List<Kenno> listKenno = new List<Kenno>();
            for (int i = 2; i < combine.ChildNodes.Count - 2; i++)
            {
                Kenno model = new Kenno();
                model.Date = combine.ChildNodes[i].ChildNodes[1].InnerText.Split('#')[0];
                model.Period = combine.ChildNodes[i].ChildNodes[1].InnerText.Split('#')[1];
                
                string[] number = combine.ChildNodes[i].ChildNodes[3].InnerText.Split(' ');
                
                foreach(string num in number)
                {
                    model.listNumber.Add(num);
                }
                model.MaxMin = combine.ChildNodes[i].ChildNodes[5].InnerText;
                model.Parity = combine.ChildNodes[i].ChildNodes[7].InnerText;
                listKenno.Add(model);
            }
            var x = listKenno;
        }
    }
}
=====================================
namespace MinhNgocNet
{
    public class XSMNViewModel
    {
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string DB { get; set; }
        public string G1 { get; set; }
        public string G2 { get; set; }
        public List<string> G3 { get; set; } = new List<string>();
        public List<string> G4 { get; set; } = new List<string>();
        public string G5 { get; set; }
        public List<string> G6 { get; set; } = new List<string>();
        public string G7 { get; set; }
        public string G8 { get; set; }
    }
    public class XSMNPage
    {
        public XSMNViewModel ProvinceOne { get; set; }
        public XSMNViewModel ProvinceTow { get; set; }
        public XSMNViewModel ProvinceThree { get; set; }
        public XSMNViewModel ProvinceFour { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {

            DateTime d = DateTime.Now;
            string dtest = d.ToString("dd-MM-yyyy");

            string day = "27-03-2021";
            string url = "https://www.minhngoc.net.vn/ket-qua-xo-so/" + day + ".html";

            //get HTMLs
            HtmlWeb web = new HtmlWeb();
            var client = new HttpClient();
            HtmlDocument htmlDoc = new HtmlDocument();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                Console.Write("Lỗi ");
            }
            var body = await response.Content.ReadAsStringAsync();
            htmlDoc.LoadHtml(body);

            //lấy tất cả tables
            var tables = htmlDoc.DocumentNode.SelectNodes($"//div[@class='box_kqxs']");

            var reduceLoopTimes = tables[0].ChildNodes[3].ChildNodes[0].ChildNodes[1].ChildNodes[0].ChildNodes[3].ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes.Count;

            //tạo list 
            List<XSMNPage> listSXMNs = new List<XSMNPage>();
            for (int xsRound = 0; xsRound < tables.Count; xsRound += 3)
            {
                //lấy ra date
                var dateStr = tables[xsRound].ChildNodes[1].ChildNodes[0].ChildNodes[1].ChildNodes[0].ChildNodes[3].InnerText.Split('-')[1];
                //tạo đối tượng Page: 4list
                XSMNPage sXMNPage = new XSMNPage();

                var combineCount = tables[xsRound].ChildNodes[3].ChildNodes[0].ChildNodes[1].ChildNodes[0].ChildNodes[3].ChildNodes[1].ChildNodes[0].ChildNodes.Count;

                for (int j = 0; j < combineCount; j++)
                {
                    var combine = tables[xsRound].ChildNodes[3].ChildNodes[0].ChildNodes[1].ChildNodes[0].ChildNodes[3].ChildNodes[1].ChildNodes[0].ChildNodes[j].ChildNodes[0].ChildNodes[0];

                    var xSMNViewModel = new XSMNViewModel();
                    xSMNViewModel.Date = DateTime.Parse(dateStr);

                    for (int i = 0; i < reduceLoopTimes; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                xSMNViewModel.City = combine.ChildNodes[i].InnerText;
                                break;
                            case 2:
                                xSMNViewModel.G8 = combine.ChildNodes[i].InnerText;
                                break;
                            case 3:
                                xSMNViewModel.G7 = combine.ChildNodes[i].InnerText;
                                break;
                            case 4:
                                int flagG6 = 0;
                                int flagG6Step = 4;
                                while (flagG6 < 9)
                                {
                                    string G6Full = combine.ChildNodes[i].InnerText;
                                    xSMNViewModel.G6.Add(combine.ChildNodes[i].InnerText.Substring(flagG6, flagG6Step));
                                    flagG6 += 4;
                                }
                                break;
                            case 5:
                                xSMNViewModel.G5 = combine.ChildNodes[i].InnerText;
                                break;
                            case 6:
                                int flagG4 = 0;
                                int flagG4Step = 5;
                                while (flagG4 < 31)
                                {
                                    string G4Full = combine.ChildNodes[i].InnerText;
                                    xSMNViewModel.G4.Add(combine.ChildNodes[i].InnerText.Substring(flagG4, flagG4Step));
                                    flagG4 += 5;
                                }
                                break;
                            case 7:
                                int flagG3 = 0;
                                int flagG3Step = 5;
                                while (flagG3 < 6)
                                {
                                    string G3Full = combine.ChildNodes[i].InnerText;
                                    xSMNViewModel.G3.Add(combine.ChildNodes[i].InnerText.Substring(flagG3, flagG3Step));
                                    flagG3 += 5;
                                }
                                break;
                            case 8:
                                xSMNViewModel.G2 = combine.ChildNodes[i].InnerText;
                                break;
                            case 9:
                                xSMNViewModel.G1 = combine.ChildNodes[i].InnerText;
                                break;
                            case 10:
                                xSMNViewModel.DB = combine.ChildNodes[i].InnerText;
                                break;
                            default:
                                break;
                        }
                    }
                    switch (j)
                    {
                        case 0:
                            sXMNPage.ProvinceOne = xSMNViewModel;
                            break;
                        case 1:
                            sXMNPage.ProvinceTow = xSMNViewModel;
                            break;
                        case 2:
                            sXMNPage.ProvinceThree = xSMNViewModel;
                            break;
                        case 3:
                            sXMNPage.ProvinceFour = xSMNViewModel;
                            break;
                    }
                }
                listSXMNs.Add(sXMNPage);
            }
        }
    }
}
==============================================
 public class Program
    {
        private static async Task Main(string[] args)
        {
            
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

           
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("job1", "group1")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(2)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
            await Task.Delay(TimeSpan.FromSeconds(10));
            await scheduler.Shutdown();
        }

        public class HelloJob : IJob
        {
            public async Task Execute(IJobExecutionContext context)
            {
                await Console.Out.WriteLineAsync("Loooooooooooooooooooooooooooo");
            }
        }
    }
     */





