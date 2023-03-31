# CoreMVCUyg
CoreMVCRestoranP
1.	 Proje konusuna uygun iki ayrı tema bulunur.
●	Admin Panel
●	Kullanıcı arayüz teması
2.	“HTTrack.exe” uygulaması ile bulunan bu iki tema indirilir.

3.	Visual Studio 22-Yeni Proje Oluştur-Asp.Net Core web Uygulaması(Model-Görünüm-Denetliyici) adımları ile proje oluşturulur.

4.	Visual Studio 22 programında proje ilk oluşturulurken “Kimlik Doğrulaması Türü-Bireysel Kullanıcı Hesapları” seçeneği mutlaka seçilmelidir. Çünkü “Login.cshtml”, “Register.cshtml" gibi sayfalar için gereklidir.

5.	Öncelikle indirilen bu temalardan “Kullanıcı arayüz teması” klasörü içerisinde bulunan “assets” klasörü projemiz içerisinde bulunan “wwwroot” klasörü içerisine kopyalanır.

6.	Daha sonra, “Kullanıcı arayüz teması” klasörü içerisinde bulunan html sayfaları Notepad++ ile html kodları açılarak uygun sayfalara bu kodlar yerleştirilir.
●	Home-Index.cshtml
●	About-Index.cshtml
●	Contact-Index.cshtml  gibi..

7.	Ancak, “Views-Shared” klasörü içerisinde bulunan “_Layout.cshtml” sayfasında bütün sayfalarda görünmesini istediğimiz kodlar yer almalıdır. Ayrıca bu sayfada unutulmaması gereken @RenderBody() ve @await RenderSectionAsync("Scripts", required: false) kodları eklenmelidir.
●	Css
●	Script
●	Top Navbar
●	Navbar Menu
●	Footer gibi..

8.	Son olarak “_Layout.cshtml” sayfası dahil olmak üzere bütün “.cshtml” sayfalarında bulunan “<link>, <script> ve <img src>” taglarının dosya yolları düzenlenmelidir. 
●	~/assets/css/style.css gibi..
9.	Bir “.cshtml” sayfası “Controller” olmadan çalışamaz. Bu nedenle,
●	Home-Index.cshtml
●	About-Index.cshtml
●	Contact-Index.cshtml  gibi.. 
bütün html sayflarının  projemiz içerisinde bulunan “Controllers” klasörü içerisinde “Controller” ‘ları oluşturulmalıdır. “Controller” ‘lar,  projemiz içerisinde bulunan “Controllers” klasörüne sağ tıklayıp Ekle-Denetleyici seçilerek oluşturulmalıdır.
●	HomeController.cs
●	AboutController.cs
●	ContactController.cs gibi..

10.	Bütün html sayfaları (.cshtml) oluşturulduktan sonra her sayfanın içeriğine göre projemizde bulunan “Model” klasörü içerisinde verilerimizin kaydedileceği tablolar oluşturulur. Bu tablolar class olarak oluşturulmalıdır.
●	Home.cs
●	About.cs
●	Slider.cs gibi..

11.	“Data-ApplicationDbContext” klasörü içerisine tabloların “DbSet” leri oluşturulur. Ancak aşağıda verilen kod bloğunun DbSet kodlarının üzerine eklenmesi unutulmamalıdır.
protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the     defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);}

12.	Projemiz içerisinde bulunan “apsettings.json” dosyası içerisine veritabanı bağlantı yolu ayarları yazılır.
●	"DefaultConnection": "Server=.;Database=RestaurantDB;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true" gibi..

13.	“Data-Migrations” klasöründe migration eklenir.

14.	“Araçlar-Nuget Paket Yöneticisi-Nuget paket yönetici konsoluna tıklanır. Açılan terminelde PM> add-migration ornek yazıldıktan sonra Enter’a basılır, böylece “Migrations” klasörü altında 234325345_ornek.cs gibi migration oluşmuş olur.

15.	Migration oluşturma işleminden sonra PM> update-database yazdıktan sonra Enter’a basılır ve tablolarımız MSSQL veritabanında tablolarımız oluşur.

16.	Admin Panel işlemlerine geçilir. Admin Paneli CRUD işlemleri için kullanırız. CRUD işlemleri ise Ekleme, Silme, Güncelleme gibi işlemlerdir.

17.	Projemiz içerisinde bulunan “Areas” klasörü altında “Admin” klasörü oluşturulur. Daha sonra “Admin” klasörü altında ise “Views” ve “Controllers” klasörleri de oluşturulur. “Views” klasörü içerisinde “Shared” klasörü oluşturulur. “Shared” klasörü içerinde de “_LayoutAdmin.cshtml” sayfası oluşturulur”Razor Görünümü Boş”. Admin panelin anasayfası için de “Admin-Views-Dashaboard-Index.cshtml sayfası oluşturulur. “Dashboard-Index.cshtml” sayfasının çalıştırılabilmesi içinde “Admin-Controllers-DashboardController.cs” oluşturulmalıdır.

DashboardController.cs kodu ise 
public class DashboardController : Controller
	{
		[Area("Admin")]
		public IActionResult Index()
		{
			return View();
		}
}

şeklinde olmalıdır.

18.	Projemiz içerisinde bulunan “_ViewStart.cshtml” ve “_ViewImports.cshtml” razor sayfalarının kopyalanıp “Admin” klasörü içerisine yapıştırılması unutulmamalıdır ve “_ViewStart.cshtml” razor sayfasında yer alan Layout: “_Layout” ise Layout: “_LayoutAdmin” şeklinde mutlaka değiştirilmelidir.

19.	İndirilen temalardan “Admin Panel”  teması içerisinde bulunan 
●	Css
●	Script
●	Top Navbar
●	Sidebar (Modüllerin olduğu menü)
●	Navbar Menu
●	Footer gibi..
her sayfada görünmesini istediğimiz kodları “_LayoutAdmin.cshtml” sayfası içerisine eklenir.
20.	Admin Panelin anasayfasında görünmesini istediğimiz kodları ise “Dashboard-Index.cshtml” sayfasına eklenir.

21.	“_LayoutAdmin.cshtml” sayfası ve “Dashboard-Index.cshtml” sayfaları oluşturulduktan sonra Admin panelde bulunan sidebar menü düzenlenmelidir. Yani sidebar menü içerisinde modüller düzelenmelidir. 
●	Anasayfa
✔	Ekle
✔	Listele
●	Hakkımızda
✔	Ekle
✔	Listele gibi..
22.	 İndirilen temalardan “Admin Paneli” temasının klasörü içerisinde bulunan “assets” klasörü projemiz içerisinde bulunan “wwwroot” klasörü içerisine yeni bir klasör oluşturulup içerisine kopyalanır. (Örneğin: “Full-assets”)

23.	Admin Panel’de  “Model” klasörü içerisinde oluşturduğumuz tablolara göre uygun “.cshtml” sayfaları oluşturulur.
●	Homes-Create.cshtml-Delete.cshtml-Edit.cshtml-Index.cshtml gibi..

24.	“Create,Delete,Edit,Index” sayfaları oluşturulurken “Areas-Admin” klasörü içerisinde bulunan Controllers kalsörüne sağ tıklayıp oluşturulması gerekmektedir. Controllers klasörüne sağ tıklayınız-Ekle-Denetleyici-Entity Framework kullanarak görünümler ile MVC Denetleyicisi seçilir-Model Sınıfı seçilir (Örneğin:Home.cs)-Veri bağlamı sınıfı seçilir (Örneğin:ApplicationDbContext)-Ekle butonuna tıklanır.

25.	“Admin-Controllers”(entity kullanarak ekle) klasöründe örneğin “HomesController.cs” sayfası oluşmuş olur ve “Admin-Views” klasöründe ise örneğin “Homes klasörü altında-create-delete-edit ve index.cshtml” sayfaları otomatik olarak oluşturulur. Bu sayfalar otomatik olarak oluşturulduktan sonra “Admin Panel” teması klasörü içerisinde bulunan bulunan html sayfaları Notepad++ ile html kodları açılarak uygun sayfalara (create-delete-edit ve index.cshtml) bu kodlar yerleştirilir.(silmek için table) (listelemek için form) create ,edit –form (delete, index – datable)
 
26.	Son olarak “_LayoutAdmin.cshtml” sayfası dahil olmak üzere bütün “.cshtml” sayfalarında bulunan “<link>, <script> ve <img src>” taglarının dosya yolları düzenlenmelidir. 
●	~/full/assets/css/style.css gibi..

27.	Daha sonra “Admin Paneli” için “Login.cshtml” ve “Register.cshtml” sayfaları düzenlenmelidir.

28.	“Areas” klasörü altında “Identity-Pages” klasörleri yer almaktadır. Ancak “Pages” klasörü boş yer almaktadır. “Pages” klasörü içerisinde “Login” ve “Register” sayfaları oluşturabilmek için “Scaffolding(İskeleli)” yapısı kullanılmalıdır.

29.	“Scaffolding(İskeleli)” yapısı için projemizin adının üzerine gelip sağ tıkladıktan sonra Ekle-Yeni İskeleli Öğe seçilir-Sol menü de yer alan “Kimlik” seçilir-Daha sonra iç kısımda yer alan “Kimlik” seçilir-Ekle butonuna basılır-Son olarak açılan pencereden bütün sayfalar seçilir ve “Veri Bağlamı Sınıfı:ApplicationDbContext” olarak seçilir –Ekle butonuna basılır.

30.	Bu işlemlerden sonra “Pages” klasörü içerisinde “Account” adında bir klasör oluşturulmuş olur. Bu “Account” klasörü içerisinde “Login. cshtml” ve “Register. cshtml” gibi Account işlemleri için gerekli bütün sayfalar yer almaktadır.

31.	“Areas-Admin” klasörü içerisinde bulunan “_ViewStart.cshtml” ve “_ViewImports.cshtml” razor sayfalarının kopyalanıp “Pages-Account” klasörü içerisine yapıştırılması unutulmamalıdır.

32.	“Admin Panel” teması klasörü içerisinde bulunan bulunan html sayfaları arasından “Login. cshtml” ve “Register. cshtml” sayfaları için uygun olan html kodları Notepad++ ile açılır. “Login. cshtml” ve “Register. cshtml” sayfalarında bulunan html kodları silinip Notepad++ içerisinde açtığımız html kodları uygun sayfalara yapıştırılır. Ancak “Login. cshtml” ve “Register. cshtml” sayfalarında bulunan razor tagları silinmemelidr. Örneğin: 
@page
@model LoginModel

@{
	ViewData["Title"] = "Log in";
}
33.	“Pages-Account” klasörü içerisinde bulunan “Register.cshtml” sayfasının altında “Register.cshtml.cs” sayfası yer almaktadır. Bu “Register.cshtml.cs” sayfası açılarak 

if (_userManager.Options.SignIn.RequireConfirmedAccount)
   {
                        return RedirectToPage("ConfirmEmail", new { email = Input.Email, returnUrl = returnUrl });
   }
 	kodu aşağıdaki gibi değiştirilir.

		if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                        return RedirectToPage("Login", new { email = Input.Email, returnUrl = returnUrl });
                }
Kodun bu şekilde değiştirilmesinin sebebi, kullanıcı “Register” olduktan sonra sayfayı “Login” e yönlendirmiş oluyoruz.

34.	 DashboardController.cs sayfası içerisindeki kod bloğuna “[Authorize]” kodu eklenmelidir.
public class DashboardController : Controller
	{
		[Area("Admin")]
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}
	}

“[Authorize]” kodu ile “Kullanıcı Arayüz Teması” üzerinden “Admin Panel” ‘e geçiş yapmak istediğimizde bizi “Login.cshtml” sayfasına yönlendirip giriş yapmamızı sağlıyor. Örneğin:
(https://localhost:7137/admin)-(https://localhost:7137/Identity/Account/Login?ReturnUrl=%2Fadmin)

35.	Son olarak “Program.cs” sayfasına aşağıdaki kodlar eklenerek “Admin Paneli” işlemlerini de tamamlamış oluyoruz.

app.MapControllerRoute(
	name: "areaRoute",
	pattern:"{area:exists}/{controller=Dashboard}/{action=Index}/{id?}";

Bu kod bloğu, link satırına https://localhost:7137/admin yazdığımızda “Admin Panel” ‘in anasayfası olan “Dashboard-Index.cshtml” sayfasına yönlendirilmemizi sağlar.

builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;

});

Bu kod bloğu ise, “Admin Panel” ‘de login olurken “Authentication” hatası almamak için kullanıyoruz. 

36.	Projemizin son aşaması olan veritabanından “Kullanıcı Arayüz Teması” ‘na verileri getirme işlemleri yapılmalıdır. Verileri “Components(Bileşenler)” aracılığı ile “Index.cshtml” sayfalarında görüntüleyebiliriz. Çünkü bir “Index.cshtml” sayfasında sadece bir tane model kullanabiliyoruz, birden fazla model kullanamıyoruz. Bu nedenle Bileşen oluşturma işlemi, bir “Index.cshtml” sayfasının html kodlarını parçalama işlemidir.

37.	 Öncelikle “Areas-Admin” klasörü altında bulunan “Views” klasöründe değil, projemizin içerisinde bulunan “Views” klasörü içerisindeki “Shared” klasörü içinde “Components” adında bir klasör oluşturmalıyız. 

38.	“Components” klasörü içerisinde, bir “Index.cshtml” sayfasının html kodlarının parçalanmış sayfaları bulunur. Örneğin:
●	Home-Index.cshtml sayfası 
✔	Footer-Default.cshtml
✔	NavbarMenu-Default.cshtml
✔	AnasayfaIcerik-Default.cshtml gibi bileşenlere ayrılmalıdır.

39.	Bir “.cshtml” sayfası “Controller” olmadan çalışamaz. Bu nedenle “Default.cshtml” sayfaları için “Controller” görevi gören “ViewComponent” ‘ler oluşturulmalıdır.

40.	“ViewComponent” ‘ler oluşturabilmek için projemize sağ tıklayıp yeni bir klasör oluşturuyoruz ve adına “ViewComponents” yazıyoruz. Bu “ViewComponents” klasörü içerisine “ViewComponent” ‘lerimizi  “Component” adı ile aynı olacak şekilde oluşturuyoruz. Ayrıca “ViewCopmonent” ‘ler class olarak oluşturulur. Örneğin:

●	FooterViewComponent.cs
●	NavbarMenuViewComponent.cs
●	AnasayfaIcerikViewComponent.cs gibi..

41.	“Components” ve “ViewComponents” ‘ler oluşturulduktan sonra “Default.cshtml” sayfalarında veri çekme işlemleri yapılır. Örneğin: AnasayfaIcerik-Default.cshtml için,

@model IEnumerable<CoreMVCUyg.Models.Home>
@foreach (var item in Model)
{
	<div class="row">
		<div class="col-md-6">
			<div class="restaurant-about">
				<h1>@item.Header</h1>
				<h4>@item.ShortDescription</h4>
				<p>@item.Description</p>

			</div>
		</div>
		<div class="col-md-6">
			<div class="restaurant-about-pic"><img src="~/Uploads/@item.ImagePath" alt=""></div>
		</div>
	</div>
 }

42.	Veri çekme işlemi yapıldıktan sonra örneğin “Home-Index.cshtml” sayfasında bu “AnasayfaIcerik-Default.cshtml” ‘in “Componenti” ‘nin yolu verilmelidir. Örneğin: 

@await Component.InvokeAsync("AnasayfaIcerik") gibi.. Ayrıca çift tırnak içerisinde yazılan ifade “Component” adı olmalıdır
