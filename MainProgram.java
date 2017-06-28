import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.net.MalformedURLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.apache.commons.io.output.FileWriterWithEncoding;

import com.gargoylesoftware.htmlunit.CookieManager;
import com.gargoylesoftware.htmlunit.FailingHttpStatusCodeException;
import com.gargoylesoftware.htmlunit.WebClient;
import com.gargoylesoftware.htmlunit.WebResponse;
import com.gargoylesoftware.htmlunit.html.DomAttr;
import com.gargoylesoftware.htmlunit.html.DomText;
import com.gargoylesoftware.htmlunit.html.HtmlAnchor;
import com.gargoylesoftware.htmlunit.html.HtmlDivision;
import com.gargoylesoftware.htmlunit.html.HtmlPage;
import com.gargoylesoftware.htmlunit.html.HtmlTableDataCell;
import com.opencsv.CSVWriter;
import com.util.csv.Singleton;

public class MainProgram {

	private Map<String, String> mapCategories = new HashMap<String, String>();
	CookieManager cookieManager = new CookieManager();
	final String _SPLITTING_STRING = "###";
	private static String csvOutputFile = "output.csv";

	public static void main(String[] args) throws IOException {

		MainProgram m = new MainProgram();
		m.createHeaderInOutputFile(csvOutputFile);
		m.getPage();
	}

	public void getPage() throws IOException {

		// step 1: getting all categories

		HtmlPage page = scrapPage("http://www.bookoffonline.co.jp/",
				"c:/temp/out.html");

		List<DomAttr> listOfCateg = (List<DomAttr>) page
				.getByXPath("//*[@id='left']/div[8]/div/ul/li/ul/li/div/div/a/@href");

		for (DomAttr oneResult : listOfCateg) {
			try {
				try {
					String hrefLink = oneResult.getValue();
					if (hrefLink != null
							&& !hrefLink.trim().equals("")) {
						System.out.println(hrefLink);
						mapCategories.put(hrefLink, "");
					}
				} catch (Exception e) {
					System.out.println(e.getMessage());
				}

			} catch (Exception e) {
				System.out.println(e.getMessage());
			}
		}

		
		
		// step 2: looping on categories. For each category, visit all page list
		mapCategories.forEach((categoryUrl, v) -> {
			
			try 
			{
				
				System.out.println("treating the following category: " + categoryUrl);
				
				boolean paginating = true;
				int counterPagination = 0;

				//pagination
				while(paginating)
				{
					counterPagination++;
					String categoryUrlWithPagination = categoryUrl + ",p=" + counterPagination;
					HtmlPage page2 = scrapPage(categoryUrlWithPagination,"c:/temp/out2.html");
					
					List<DomAttr> listOfItems = (List<DomAttr>) page2
							.getByXPath("//*[@id='resList']/form/div/div[1]/p/a/@href");
	
					
					for (DomAttr oneResult : listOfItems) {
							try {
								String itemLink = oneResult.getValue();
								if (itemLink != null
										&& !itemLink.trim().equals("")) {
									String itemUrl = "http://www.bookoffonline.co.jp" + itemLink;
									System.out.println("\nlooking for item url: \n" + itemUrl);
									
									//3. getting details from the item detail page
									HtmlPage page3 = scrapPage(itemUrl,"c:/temp/out3.html");
	
									String strTitle = "";
									String strBrandNewPricing = "";
									String strUsedPricing = "";
									String strJan = "";
									String strAvailibility = "false";
	
									try
									{
										DomText title = (DomText) page3.getByXPath("//*[@id='ttl_det']/text()").get(0);
										strTitle = title.asText().trim();
										System.out.println("strTitle=" + strTitle);
									}
									catch(Exception e)
									{
										System.out.println(e.getMessage());
									}
									
									try
									{
										HtmlTableDataCell brandNewPricing = (HtmlTableDataCell) page3.getByXPath("//*[@id='spec_table']/tbody/tr[1]/td").get(0);
										strBrandNewPricing = brandNewPricing.asText().trim();
										System.out.println("strBrandNewPricing=" + strBrandNewPricing);
									}
									catch(Exception e)
									{
										System.out.println(e.getMessage());
									}
									
									try
									{
										DomText usedPricing = (DomText) page3.getByXPath("//*[@id='spec_table']/tbody/tr[2]/td/text()").get(0);
										strUsedPricing = usedPricing.asText().trim();
										System.out.println("strUsedPricing=" + strUsedPricing);
									}
									catch(Exception e)
									{
										System.out.println(e.getMessage());
									}
									
									try
									{
										DomText jan = (DomText) page3.getByXPath("//*[@id='info02']/div/div[2]/table/tbody/tr[3]/td/text()").get(0);
										strJan = jan.asText().trim();
										System.out.println("strJan=" + strJan);
									}
									catch(Exception e)
									{
										System.out.println(e.getMessage());
									}
									
									try
									{
										DomAttr availibility = (DomAttr) page3.getByXPath("//*[@id='buybghd_old']/li/a/img/@src").get(0);
										if (availibility.getValue().trim().equals("../images/parts/detail/b_cart_old110203.gif"))
										{
											strAvailibility = "true";
										}
										System.out.println("strAvailibility=" + strAvailibility);
									}
									catch(Exception e)
									{
										System.out.println(e.getMessage());
									}
									
									saveEntry(strTitle, strBrandNewPricing, strUsedPricing, strJan, strAvailibility, page3.getPageEncoding());

								}
							} catch (Exception e) {
								System.out.println(e.getMessage());
							}
							
	
						}
					
					
						// looking is there is a next page or not
						try
						{
						
							HtmlAnchor nextAnchor = (HtmlAnchor) page2.getByXPath("//*[@id='resList']/form/div[24]/div[2]/a[5]").get(0);
							String strNextAnchor = nextAnchor.asText().trim();
							System.out.println("strNextAnchor=" + strNextAnchor);
							
							if(strNextAnchor.equals("次へ>>"))
							{
								paginating = true;
							}
							else
							{
								try
								{
								
									nextAnchor = (HtmlAnchor) page2.getByXPath("//*[@id='resList']/form/div[24]/div[2]/a[6]").get(0);
									strNextAnchor = nextAnchor.asText().trim();
									System.out.println("strNextAnchor=" + strNextAnchor);
									
									if(strNextAnchor.equals("次へ>>"))
									{
										paginating = true;
									}
									else
									{
										paginating = false;
									}
								}
								catch(Exception e)
								{
									System.out.println(e.getMessage());
								}
							}
						}
						catch(Exception e)
						{
							System.out.println(e.getMessage());
						}
						
				}
				
				
			} catch (Exception e) {
				e.printStackTrace();
			}
			
		});

	}

	public HtmlPage scrapPage(String urlToLookFor, String saveToPath)
			throws FailingHttpStatusCodeException, MalformedURLException,
			IOException {
		try (final WebClient webClient = new WebClient()) {

			webClient.getOptions().setThrowExceptionOnScriptError(false);
			webClient.setCookieManager(cookieManager);
			webClient.getCookieManager().clearCookies();

			final HtmlPage page = webClient.getPage(urlToLookFor);

			 // /// DEBUG
//			 WebResponse response = page.getWebResponse();
//			 String contentAsString = response.getContentAsString();
//			 saveHtmlToFile(contentAsString, "c:/temp/out.html", page.getPageEncoding());
			 // /// DEBUG

			return page;
		}

	}

	private void saveHtmlToFile(String contentAsString, String filePath, String encoding)
			throws IOException {
		// Save the response in a file
		// String filePath = "c:/temp/out.html";
		BufferedWriter bw = new BufferedWriter(new FileWriterWithEncoding(
				new File(filePath), encoding));
		bw.write(contentAsString);
		bw.close();

		// Open the page with a browser
		Runtime.getRuntime().exec(
				"C:/Program Files (x86)/Google/Chrome/Application/chrome.exe "
						+ filePath);
	}
	
	private static void createHeaderInOutputFile(String csvOutputFile)
			throws IOException {

		String headers = "Title#Brand New Pricing#Used Pricing#JAN#Availibility";
		String[] header = headers.split("#");

		// save header in csv file
		CSVWriter csvWriter = new CSVWriter(new FileWriter(csvOutputFile), ';');
		csvWriter.writeNext(header);

		try {
			csvWriter.close();
		} catch (Exception ee) {
			ee.printStackTrace();
		}
	}
	
	private void saveEntry(String strTitle, String strBrandNewPricing, String strUsedPricing, String strJan, String strAvailibility, String encoding) {

		List<String[]> rows = new ArrayList<String[]>();
		String allData = strTitle.replaceAll(";", " ") 
				+ _SPLITTING_STRING + strBrandNewPricing.replaceAll(";", " ")
				+ _SPLITTING_STRING + strUsedPricing.replaceAll(";", " ")
				+ _SPLITTING_STRING + strJan.replaceAll(";", " ")
				+ _SPLITTING_STRING + strAvailibility.replaceAll(";", " ");
		String[] row = allData.split(_SPLITTING_STRING);
		rows.add(row);
		Singleton.getInstance().writeToFile(csvOutputFile , rows, encoding);
	}
	
}
