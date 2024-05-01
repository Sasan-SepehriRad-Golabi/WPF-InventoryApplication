using AForge.Video;
using AForge.Video.DirectShow;
using InventoryApplication.DataAccess;
using InventoryApplication.ViewModels.Commands;
using InventoryApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace InventoryApplication.ViewModels
{
    public class SearchNewMaterialViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private MaterialDesignThemes.Wpf.SnackbarMessageQueue _MySnackbarMessageQueueRegisterComp;

        public MaterialDesignThemes.Wpf.SnackbarMessageQueue MySnackbarMessageQueueRegisterComp
        {
            get { return _MySnackbarMessageQueueRegisterComp; }
            set { _MySnackbarMessageQueueRegisterComp = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MySnackbarMessageQueueRegisterComp")); }
        }
        private MaterialDesignThemes.Wpf.SnackbarMessageQueue _MySnackbarMessageQueueRegisterInv;

        public MaterialDesignThemes.Wpf.SnackbarMessageQueue MySnackbarMessageQueueRegisterInv
        {
            get { return _MySnackbarMessageQueueRegisterInv; }
            set { _MySnackbarMessageQueueRegisterInv = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MySnackbarMessageQueueRegisterInv")); }
        }
        private bool _RegisterCompanySnackBarActivation;

        public bool RegisterCompanySnackBarActivation
        {
            get { return _RegisterCompanySnackBarActivation; }
            set { _RegisterCompanySnackBarActivation = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RegisterCompanySnackBarActivation")); }
        }
        private bool _RegisterInventorySnackBarActivation;

        public bool RegisterInventorySnackBarActivation
        {
            get { return _RegisterInventorySnackBarActivation; }
            set { _RegisterInventorySnackBarActivation = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RegisterInventorySnackBarActivation")); }
        }
        private List<Models.Material> _NamesofMaterialslist;
        public List<Models.Material> NamesofMaterialslist
        {
            get { return _NamesofMaterialslist; }
            set { _NamesofMaterialslist = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NamesofMaterialslist")); }
        }
        private ObservableCollection<Models.Material> _NamesofMaterials;
        public ObservableCollection<Models.Material> NamesofMaterials
        {
            get { return _NamesofMaterials; }
            set { _NamesofMaterials = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NamesofMaterials")); }
        }
        private ObservableCollection<Models.Material> _listofMaterials;
        public ObservableCollection<Models.Material> listofMaterials
        {
            get { return _listofMaterials; }
            set { _listofMaterials = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("listofMaterials")); }
        }

        private ObservableCollection<Models.Inventory> _NameOFStores;
        public ObservableCollection<Models.Inventory> NameOFStores
        {
            get
            {
                return _NameOFStores;
            }
            set
            {
                _NameOFStores = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameOFStores"));
            }
        }
        private ObservableCollection<Models.Material> _ListofSearchedMaterialsMoreDetails;
        public ObservableCollection<Models.Material> ListofSearchedMaterialsMoreDetails
        {
            get
            {
                return _ListofSearchedMaterialsMoreDetails;
            }
            set
            {
                _ListofSearchedMaterialsMoreDetails = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListofSearchedMaterialsMoreDetails"));
            }
        }
        private ObservableCollection<Models.ProviderCompany> _ListofCompanies;
        public ObservableCollection<Models.ProviderCompany> ListofCompanies
        {
            get
            {
                return _ListofCompanies;
            }
            set
            {
                _ListofCompanies = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListofCompanies"));
            }
        }
        InventoryApplicationContext ctx;
        public ICommand RegisterNewCompanyNameCommand { get; set; }
        public ICommand MyAddStoreFromSearch { get; set; }
        public ICommand OpenExitMaterialDialogParticularCommand { get; set; }
        public ICommand MyApplyChangesInExitMaterialDialog { get; set; }
        public ICommand MyGetReportDetails { get; set; }
        private DateTime _time;

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Time")); }
        }
        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Date")); }
        }

        private Models.Material _NewMaterial;

        public Models.Material NewMaterial
        {
            get { return _NewMaterial; }
            set { _NewMaterial = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewMaterial")); }
        }
        private Models.Inventory _ICTStore;

        public Models.Inventory ICTStore
        {
            get { return _ICTStore; }
            set { _ICTStore = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ICTStore")); }
        }
        private Models.ProviderCompany _MyProviderCompany;

        public Models.ProviderCompany MyProviderCompany
        {
            get { return _MyProviderCompany; }
            set { _MyProviderCompany = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyProviderCompany")); }
        }

        public ICommand AddCompanyFromSearch { get; set; }
        public ICommand MyGetSearchDetails { get; set; }   
        public ICommand MyRegisterNewMaterialCommand { get; set; }
        public SearchNewMaterial mysearchnewmaterial { get; set; }
        private MaterialDesignThemes.Wpf.SnackbarMessageQueue _MainMessageQueue1;

        public MaterialDesignThemes.Wpf.SnackbarMessageQueue MainMessageQueue1
        {
            get { return _MainMessageQueue1; }
            set { _MainMessageQueue1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MainMessageQueue1"));}
        }
        private bool _MainSnackIsActive1;

        public bool MainSnackIsActive1
        {
            get { return _MainSnackIsActive1; }
            set { _MainSnackIsActive1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MainSnackIsActive1")); }
        }
        public MaterialDesignThemes.Wpf.SnackbarMessageQueue MainMessageQueue_personelMessage { get; set; }
        public bool MainSnackIsActive_personelIsActive;
        public ICommand MyRemoveTheWholeMaterialCommand { get; set; }
        public void removeTheWholeMaterialCommand(object sender,RoutedEventArgs e)
        {
            try
            {
                UnitOfWork unii = new UnitOfWork(ctx);
                Models.Material MaterialToRemove = new Models.Material();
                List<Models.Material> mats = unii.MyMaterialsRep.find(x => x.Name == ((Button)e.Source).CommandParameter.ToString()).Where(x=>x.NumberofMaterial!="-45").ToList();
                foreach (Models.Material mat in mats)
                {
                    mat.PrivateNumberofMaterial = mat.PrivateNumberofMaterial + "-" + "deleted("+DateTime.UtcNow.ToString()+")";
                    mat.NumberofMaterial = "-45";
                    unii.MyMaterialsRep.Add(mat);
                    ctx.Entry(mat).State = System.Data.Entity.EntityState.Modified;
                }
                unii.complete();
                MyMainMessageQueue.Enqueue("اطلاعات تغییر یافت");
                MyMainSnackIsActive = true;
                executeGetSearchDetails();
                //ctx.Entry(NewMaterial).State = System.Data.Entity.EntityState.Detached;
            }
            catch (Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        public SearchNewMaterialViewModel(SearchNewMaterial sv)
        {
            mysearchnewmaterial = sv;
            Date = DateTime.Now;
            Time = DateTime.Now;
            MainMessageQueue1 = new MaterialDesignThemes.Wpf.SnackbarMessageQueue();
            MainMessageQueue_personelMessage = new MaterialDesignThemes.Wpf.SnackbarMessageQueue();
            MainSnackIsActive_personelIsActive = false;
            NewMaterial = new Models.Material();
            MatrialToExit = new Models.Material();
            MyProviderCompany = new Models.ProviderCompany();
            MaterialCompanytoSearch = new Models.ProviderCompany();
            MaterialStoretoSearch = new Models.Inventory();
            ICTStore = new Models.Inventory();
            ListofSearchedMaterialsMoreDetails = new ObservableCollection<Models.Material>();
            MyInventory = new Models.Inventory();
            MyCompany = new Models.ProviderCompany();
            PeronelForReport = new Models.Peronel();
            MyPersonelGetPictureFromWebComCommand = new Commands.GetPictureFromWebCamPersonelInSearch(this);
            RegisterNewCompanyNameCommand =new SearchNewMaterialCommand(this);
            MyRegisterNewMaterialCommand = new UpdateNewMaterialCommand(this);
            MyRemoveTheWholeMaterialCommand = new RemoveTheWholeMaterialCommand(this);
            MyRegisterNewPersonelCommand = new Commands.RegisterNewPersonelCommandInExit(this);
            MyApplyChangesInExitMaterialDialog = new ApplyChangesInExitMaterialDialog(this);
            MyGetReportDetails = new GetReportDetailsCommand(this);
            OpenExitMaterialDialogParticularCommand = new OpenExitMaterialDialogParticularCommand(this);
            MyAddStoreFromSearch = new AddStoreFromSearch(this);
            AddCompanyFromSearch = new AddCompanyFromSearch(this);
            MyGetSearchDetails = new GetSearchDetails(this);
            SearchedMaterialDetails = new Models.Material();
            listofMaterials = new ObservableCollection<Models.Material>();
            MySnackbarMessageQueueRegisterComp = new MaterialDesignThemes.Wpf.SnackbarMessageQueue();
            MySnackbarMessageQueueRegisterInv = new MaterialDesignThemes.Wpf.SnackbarMessageQueue();
            MyMainMessageQueue = new MaterialDesignThemes.Wpf.SnackbarMessageQueue();
            ctx = new InventoryApplicationContext();
            NewPersonel = new Models.Peronel();
            NameofPersonels = new ObservableCollection<Models.Peronel>(getNameofPersonels());
            NameofPersonels0 = new ObservableCollection<Models.Peronel>(getNameofPersonels());
            NameofPersonels1 = new ObservableCollection<Models.Peronel>(getNameofPersonels());
            NameofPersonels2 = new ObservableCollection<Models.Peronel>(getNameofPersonels());
            NameofPersonels3 = new ObservableCollection<Models.Peronel>(getNameofPersonels());
            UnitOfWork uni = new UnitOfWork(ctx);
            MyWorkerforSearchkeydowncompany = new UnitOfWork(ctx);
            MyWorkerforSearchkeydowninventory = new UnitOfWork(ctx);
            MyWorkerforSearchkeydownmaterial = new UnitOfWork(ctx);
            NamesofMaterialslist = new List<Models.Material>();
            NamesofMaterials = getnameofMaterialsGrouped(null);
            ListOfPersonels = new ObservableCollection<Models.Peronel>(getNameofPersonels());
            (NameOFStores, ListofCompanies) = getNameofStoresandcompanies();
            ListofSearchedMaterialsMoreDetails = new ObservableCollection<Models.Material>();
            MaterialForReport = new Models.Material();
            InventoryForReport = new Models.Inventory();
            CompanyForReport = new Models.ProviderCompany();
            ListofWebcams = new ObservableCollection<string>();
            ListofWebcams.Add("لیست وب کم ها");
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo fi in filterInfoCollection)
            {
                ListofWebcams.Add(fi.Name);
            }
            MyWebCamImage = new BitmapImage();
            MyWebCamImage_person = new BitmapImage();
            MyImageSourceVisibility0_personel = "Visible";
            MyImageSourceVisibility2_personel = "Hidden";
            MyImageSourceVisibility1_personel = "Hidden";
        }
        public ICommand MyRegisterNewPersonelCommand { get; set; }
        public bool RegisterNewPersonelCommandCanExecute()
        {
            try
            {
                if (NewPersonel != null && (NewPersonel.Company != null && NewPersonel.Company.Length > 0 && NewPersonel.Company.Length < 13) &&
               (NewPersonel.FirstName != null && NewPersonel.FirstName.Length > 0 && NewPersonel.FirstName.Length < 13) &&
               (NewPersonel.LastName != null && NewPersonel.LastName.Length > 0 && NewPersonel.LastName.Length < 13) &&
               NewPersonel.correctpersonelynumber)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void RegisterNewPersonelCommandExecute()
        {
            try
            {
                UnitOfWork uni = new UnitOfWork(ctx);
                uni.MyPersonRep.Add(NewPersonel);
                uni.complete();
                NameofPersonels0 = new ObservableCollection<Models.Peronel>(getNameofPersonels());
                ctx.Entry(NewPersonel).State = System.Data.Entity.EntityState.Detached;
                MainMessageQueue_personelMessage.Enqueue("اطلاعات با موفقیت ثبت گردید.");
                MainSnackIsActive_personelIsActive = true;
                //Timer timer = new Timer();timer.Interval = 2000; timer.Elapsed += Timer_Elapsed;
                ctx.Entry(NewPersonel).State = System.Data.Entity.EntityState.Detached;
                NewPersonel.Company = ""; NewPersonel.FirstName = ""; NewPersonel.LastName = "";
                NewPersonel.JobTitle = ""; NewPersonel.OtherPoints = ""; NewPersonel.PersonelImage = null;
                NewPersonel.PersonelyNumber = ""; NewPersonel.correctpersonelynumber = false;
            }
            catch (Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }

        //private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    MainSnackIsActive_personelIsActive = false;
        //}

        private ObservableCollection<Models.Peronel> _ListOfPersonels;

        public ObservableCollection<Models.Peronel> ListOfPersonels
        {
            get { return _ListOfPersonels; }
            set { _ListOfPersonels = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListOfPersonels")); }
        }

        private string _ReceiptForReport;

        public string ReceiptForReport
        {
            get { return _ReceiptForReport; }
            set { _ReceiptForReport = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceiptForReport")); }
        }

        FilterInfoCollection filterInfoCollection;
        public VideoCaptureDevice videoCaptureDevice { get; set; }
        private int _MyWebCamSelectedIndex;
        private string _BeginTimeofSearch;

        public string BeginTimeofSearch
        {
            get { return _BeginTimeofSearch; }
            set { _BeginTimeofSearch = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BeginTimeofSearch")); }
        }
        private string _EndTimeofSearch;

        public string EndTimeofSearch
        {
            get { return _EndTimeofSearch; }
            set { _EndTimeofSearch = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EndTimeofSearch")); }
        }

        public void ExecuteCreateReport()
        {
            try
            {
                UnitOfWork myunit = new UnitOfWork(ctx);
                IEnumerable<Models.Material> y1, y2, y3, y4, y5, y6, y7, y8, y9;
                y1 = myunit.MyMaterialsRep.GetAll().Where(x=>x.NumberofMaterial!="-45");
                foreach (Models.Material mm in y1)
                {
                    ctx.Entry(mm).Reload();
                }
                IEnumerable<Models.Receipt> receipts;
                receipts = myunit.MyReceiptsRep.GetAll();
                foreach (Models.Receipt r1 in receipts)
                {
                    ctx.Entry(r1).Reload();
                }
                MyListofAbstractMaterialsReport = new ObservableCollection<AbstractMaterialReport>();
                MyListofAbstractMaterialsReport.Clear();
                DateTime begindate, enddate;
                if (string.IsNullOrEmpty(BeginTimeofSearch) || !DateTime.TryParse(BeginTimeofSearch, out begindate)) { begindate = Convert.ToDateTime("2000/01/01"); }
                if (string.IsNullOrEmpty(EndTimeofSearch) || !DateTime.TryParse(EndTimeofSearch, out enddate)) { enddate = (DateTime.Now).Date; }
                if(string.IsNullOrEmpty(BeginTimeofSearch) || !DateTime.TryParse(BeginTimeofSearch, out begindate)|| string.IsNullOrEmpty(EndTimeofSearch) || !DateTime.TryParse(EndTimeofSearch, out enddate)){
                    y8 = y1;
                }
                else
                {
                    y8 = y1.Where(x =>(x.DateofBuying!=null) && Convert.ToDateTime(x.DateofBuying).Date >= begindate.Date && Convert.ToDateTime(x.DateofBuying).Date <= enddate.Date);
                }
                if (PeronelForReport != null && PeronelForReport.FirstName != null && PeronelForReport.LastName != null)
                {
                    y2 = y8.Where(x => (x.MaterialUser != null && (x.MaterialUser.Contains(PeronelForReport.FirstName) || x.MaterialUser.Contains(PeronelForReport.LastName))));
                }
                else
                {
                    y2 = y8;
                }
                if (InventoryForReport != null && InventoryForReport.Id != null && InventoryForReport.Id > 0)
                {
                    y3 = y2.Where(x => x.MaterialInventoryid != null).Where(x => x.MaterialInventoryid == InventoryForReport.Id);
                }
                else
                {
                    y3 = y2;
                }
                if (!string.IsNullOrEmpty(ReceiptForReport))
                {
                    y4 = y3.Where(x => x.MaterialReceiptnumber != null).Where(x => x.MaterialReceiptnumber == ReceiptForReport);
                }
                else
                {
                    y4 = y3;
                }
                //jhglj
                if (MaterialForReport != null && MaterialForReport.Name != null)
                {
                    y5 = y4.Where(x => x.Name != null).Where(x => x.Name.Contains(MaterialForReport.Name));
                }
                else
                {
                    y5 = y4;
                }
                if (CompanyForReport != null && CompanyForReport.Id != null && CompanyForReport.Id > 0)
                {
                    y6 = y5.Where(x => x.MaterialCompanyid != null).Where(x => x.MaterialCompanyid == CompanyForReport.Id);
                }
                else
                {
                    y6 = y5;
                }
                if (IsPayedReportIncluded)
                {
                    if (IsPayedReport)
                    {
                        var query = from b in y6 join b1 in receipts on b.MaterialReceiptnumber equals b1.ReceiptNumber where b1.IsPayed == 1 select b;
                        y7 = query;
                    }
                    else
                    {
                        var query = from b in y6 join b1 in receipts on b.MaterialReceiptnumber equals b1.ReceiptNumber where b1.IsPayed != 1 select b;
                        y7 = query;
                    }
                }
                else
                {
                    y7 = y6;
                }
                if (IsFinishingReportIncluded)
                {
                    if (IsFinishingReport)
                    {
                        y9 = y7.Where(x => x.RemainedNumber < Convert.ToInt32(x.MinimumAcceptableDevices));
                    }
                    else
                    {
                        y9 = y7.Where(x => x.RemainedNumber > Convert.ToInt32(x.MinimumAcceptableDevices));
                    }
                }
                else
                {
                    y9 = y7;
                }
                if (y9 != null)
                {
                    var yy = from b in y9 group b by b.Name into newout select newout;
                    RefrenceAfterSearch = yy;
                    int RemaindInSearch = 0;
                    foreach (var x in yy)
                    {
                        int counter = 0;
                        string name;
                        int remainednumber;
                        Models.Material tt = x.AsEnumerable().FirstOrDefault();
                        foreach (var x1 in x)
                        {
                            counter += Convert.ToInt32(x1.NumberofMaterial);
                        }
                        MyListofAbstractMaterialsReport.Add(new AbstractMaterialReport() { Name = tt.Name, RemainedNumber = tt.RemainedNumber, RemainedNumberInSearch = counter });
                    }
                }
        }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        public BitmapImage GetPictureFromDropPersonel(BitmapImage img)
        {
            MyImageSourceVisibility2_personel = "Hidden";
            MyImageSourceVisibility0_personel = "Visible";
            MyImageSourceVisibility1_personel = "Hidden";
            MyImageSourceVisibility_1_personel = "Hidden";
            MyResultImage_personel = img;
            return MyResultImage_personel;
        }
        public BitmapImage GetPictureFromWebCamPersonel()
        {
            MyImageSourceVisibility2_personel = "Hidden";
            MyImageSourceVisibility0_personel = "Visible";
            MyImageSourceVisibility1_personel = "Hidden";
            MyImageSourceVisibility_1_personel = "Hidden";
            MyResultImage_personel = MyWebCamImage_person;
            return MyResultImage_personel;
        }
        public int MyWebCamSelectedIndex
        {
            get { return _MyWebCamSelectedIndex; }
            set
            {
                if (value != 0)
                {
                    _MyWebCamSelectedIndex = value;
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[value - 1].MonikerString);
                    videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                    videoCaptureDevice.Start();
                }
            }
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();
                    bitmapimage.Freeze();
                    MyWebCamImage = bitmapimage;
                    MyWebCamImage_person = bitmapimage;
                }
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        private BitmapImage _MyWebCamImage;

        public BitmapImage MyWebCamImage
        {
            get { return _MyWebCamImage; }
            set
            {
                _MyWebCamImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyWebCamImage"));
            }
        }
        private BitmapImage _MyWebCamImage_person;

        public BitmapImage MyWebCamImage_person
        {
            get { return _MyWebCamImage_person; }
            set { _MyWebCamImage_person = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyWebCamImage_person")); }
        }
        public ICommand MyPersonelGetPictureFromWebComCommand { get; set; }
        public ObservableCollection<String> ListofWebcams { get; set; }
        private Models.Material _MaterialForReport;

        public Models.Material MaterialForReport
        {
            get { return _MaterialForReport; }
            set { _MaterialForReport = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialForReport")); }
        }
        private Models.Inventory _InventoryForReport;

        public Models.Inventory InventoryForReport
        {
            get { return _InventoryForReport; }
            set { _InventoryForReport = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InventoryForReport")); }
        }
        private Models.ProviderCompany _CompanyForReport;

        public Models.ProviderCompany CompanyForReport
        {
            get { return _CompanyForReport; }
            set { _CompanyForReport = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CompanyForReport")); }
        }
        private Models.Peronel _PersonelForReport;

        public Models.Peronel PersonelForReport
        {
            get { return _PersonelForReport; }
            set { _PersonelForReport = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PersonelForReport")); }
        }

        public MaterialDesignThemes.Wpf.SnackbarMessageQueue MyMainMessageQueue { get; set; }
        public bool MyMainSnackIsActive { get; set; }
        public bool CanExitMaterialParticular(object parm)
        {
            int res;
            if(int.TryParse(parm.ToString(),out res))
            {
                UnitOfWork myuni = new UnitOfWork(ctx);
               Models.Material mat= myuni.MyMaterialsRep.find(x => x.Id == res).FirstOrDefault();
                if (true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void ExitMaterialParticular(object parm)
        {
           
        }
        public bool Canexecuteupdatematerial(object parm)
        {
            if (parm !=null && NewMaterial!=null &&(parm.GetType() == NewMaterial.GetType()))
            {
                Models.Material material = (Models.Material)parm;
                int res;
                //if(!string.IsNullOrEmpty(material.Name) && !string.IsNullOrEmpty(material.MaterialRequester)
                //    && (!string.IsNullOrEmpty(material.MaterialReceiptnumber) && int.TryParse(material.MaterialReceiptnumber,out res))
                //    && (!string.IsNullOrEmpty(material.MaterialCompanyid.ToString())) && (!string.IsNullOrEmpty(material.MaterialInventoryid.ToString()))
                //    && (!string.IsNullOrEmpty(material.MinimumAcceptableDevices))&&(!string.IsNullOrEmpty(material.NumberofMaterial))
                //    && (!string.IsNullOrEmpty(material.DateofBuying)))
                if (!string.IsNullOrEmpty(material.Name) 
                    && (!string.IsNullOrEmpty(material.MinimumAcceptableDevices)) && (!string.IsNullOrEmpty(material.NumberofMaterial)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private string _MyNumofMaterial;

        public string MyNumofMaterial
        {
            get { return _MyNumofMaterial; }
            set 
            {
                _MyNumofMaterial = value;
                if (_MyNumofMaterial != NewMaterial.NumberofMaterial)
                {
                    int newres;int oldres;
                    if(int.TryParse(_MyNumofMaterial,out newres))
                    {
                        if (int.TryParse(NewMaterial.NumberofMaterial, out oldres))
                        {
                            int finalres = newres - oldres;
                            NewMaterial.RemainedNumber += finalres;
                        }
                      NewMaterial.NumberofMaterial = _MyNumofMaterial;
                    }
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyNumofMaterial")); 
            }
        }
        private string _testNewMaterialName;

        public string testNewMaterialName
        {
            get { return _testNewMaterialName; }
            set { _testNewMaterialName = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("testNewMaterialName")); }
        }


        public void Executeupdatematerial(object parm)
        {
            try
            {
                UnitOfWork unii = new UnitOfWork(ctx);
                Models.Material UpdatedMaterial = new Models.Material();
                List<Models.Material> mats = unii.MyMaterialsRep.find(x => x.Name == NewMaterial.Name).Where(x=>x.NumberofMaterial!="-45").ToList();
                if(NewMaterial.Name!= testNewMaterialName)
                {
                    foreach (Models.Material mat in mats)
                    {
                        mat.Name = testNewMaterialName;
                        mat.MinimumAcceptableDevices = NewMaterial.MinimumAcceptableDevices;
                        mat.RemainedNumber = NewMaterial.RemainedNumber;
                        unii.MyMaterialsRep.Add(mat);
                        ctx.Entry(mat).State = System.Data.Entity.EntityState.Modified;
                    }

                }
                else
                {
                    foreach (Models.Material mat in mats)
                    {
                        mat.MinimumAcceptableDevices = NewMaterial.MinimumAcceptableDevices;
                        mat.RemainedNumber = NewMaterial.RemainedNumber;
                        unii.MyMaterialsRep.Add(mat);
                        ctx.Entry(mat).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                NewMaterial.Name = testNewMaterialName;
                NewMaterial.PrivateNumberofMaterial = NewMaterial.PrivateNumberofMaterial + "-" + NewMaterial.NumberofMaterial+"("+DateTime.Now.ToString()+")";
                unii.MyMaterialsRep.Add(NewMaterial);
                ctx.Entry(NewMaterial).State = System.Data.Entity.EntityState.Modified;
                unii.complete();
                MyMainMessageQueue.Enqueue("اطلاعات تغییر یافت");
                MyMainSnackIsActive = true;
                getnameofMaterialsGrouped(null);
                executeGetSearchDetails();
                ExecuteCreateReport();
                mysearchnewmaterial.myauthenticatedUserView.myregisterview.MyViewModel.ctx.Entry(NewMaterial).Reload();
                //ctx.Entry(NewMaterial).State = System.Data.Entity.EntityState.Detached;
            }
            catch (Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        public ObservableCollection<Models.Material> getnameofMaterialsGrouped(string keytosearch)
        {
            try
            {
                List<Models.Material> templist = new List<Models.Material>();
                if (string.IsNullOrEmpty(keytosearch) || keytosearch == null)
                {
                    templist = MyWorkerforSearchkeydownmaterial.MyMaterialsRep.GetAll().Where(x=>x.NumberofMaterial!="-45").ToList();
                    var query = from b in templist group b by b.Name into outres select outres;
                    NamesofMaterialslist.Clear();
                    foreach (var x in query)
                    {
                        foreach (var x1 in x)
                        {
                            NamesofMaterialslist.Add(x1);
                            break;
                        }
                    }
                }
                else
                {
                    templist = MyWorkerforSearchkeydownmaterial.MyMaterialsRep.find(x => x.Name.Contains(keytosearch)).Where(x=>x.NumberofMaterial!="-45").ToList();
                    var query = from b in templist group b by b.Name into outres select outres;
                    NamesofMaterialslist.Clear();
                    foreach (var x in query)
                    {
                        foreach (var x1 in x)
                        {
                            NamesofMaterialslist.Add(x1);
                            break;
                        }
                    }
                }
                return new ObservableCollection<Models.Material>(NamesofMaterialslist);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public UnitOfWork MyWorkerforSearchkeydowninventory { get; set; }
        public UnitOfWork MyWorkerforSearchkeydowncompany { get; set; }
        public UnitOfWork MyWorkerforSearchkeydownmaterial { get; set; }
        public (ObservableCollection<Models.Inventory>, ObservableCollection<Models.ProviderCompany>) getNameofStoresandcompanies()
        {

            try
            {
                ObservableCollection<Models.Inventory> mylistofstores = new ObservableCollection<Models.Inventory>();
                ObservableCollection<Models.ProviderCompany> mylistofcompanies = new ObservableCollection<Models.ProviderCompany>();
                InventoryApplicationContext ctx = new InventoryApplicationContext();
                UnitOfWork uw = new UnitOfWork(ctx);

                IEnumerable<Models.Inventory> listofstores = uw.MyInventoriesRep.GetAll();
                if (listofstores.Count() == 0)
                {

                }
                else
                {
                    mylistofstores = new ObservableCollection<Models.Inventory>(uw.MyInventoriesRep.GetAll());
                }
                IEnumerable<Models.ProviderCompany> listofcompanies = uw.MyProviderCompaniesRep.GetAll();
                if (listofcompanies.Count() == 0)
                {

                }
                else
                {
                    mylistofcompanies = new ObservableCollection<Models.ProviderCompany>(uw.MyProviderCompaniesRep.GetAll());
                }


                return (mylistofstores, mylistofcompanies);
            }
            catch(Exception ex)
            {
                return (null, null);
            }
        }

        public bool CanExecuteRegisterNewCompanyFromSearch(object parm)
        {
            if (MyProviderCompany.ProperProviderCompany1&& MyProviderCompany.ProperProviderCompany2&& MyProviderCompany.ProperProviderCompany3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ExecuteRegisterNewCompanyFromSearch()
        {
            try
            {
                UnitOfWork myunit = new UnitOfWork(ctx);
                myunit.MyProviderCompaniesRep.Add(MyProviderCompany);
                myunit.complete();
                MySnackbarMessageQueueRegisterComp.Enqueue("اطلاعات ثبت گردید");
                RegisterCompanySnackBarActivation = true;
                (NameOFStores, ListofCompanies) = getNameofStoresandcompanies();
                MyProviderCompany.CallNumber = ""; MyProviderCompany.NameofCompany = ""; MyProviderCompany.LocationAddress = "";
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }

        public bool CanExecuteAddStoreFromSearch(object parm)
        {
            if(ICTStore!=null && ICTStore.ProperInventory1 && ICTStore.ProperInventory2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ExecuteAddStoreFromSearch()
        {
            try
            {
                UnitOfWork myunit = new UnitOfWork(ctx);
                myunit.MyInventoriesRep.Add(ICTStore);
                myunit.complete();
                (NameOFStores, ListofCompanies) = getNameofStoresandcompanies();
                ICTStore.Name = ""; ICTStore.Location = ""; ICTStore.Accessors = "";
                MySnackbarMessageQueueRegisterInv.Enqueue("اطلاعات ثبت شد.");
                RegisterInventorySnackBarActivation = true;
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        private string _MaterialNametoSearch;

        public string MaterialNametoSearch
        {
            get { return _MaterialNametoSearch; }
            set { _MaterialNametoSearch = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialNametoSearch")); }
        }
        private string _MaterialReceipttoSearch;

        public string MaterialReceipttoSearch
        {
            get { return _MaterialReceipttoSearch; }
            set { _MaterialReceipttoSearch = value;  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialReceipttoSearch")); }
        }
        private Models.Inventory _MaterialStoretoSearch;

        public Models.Inventory MaterialStoretoSearch
        {
            get { return _MaterialStoretoSearch; }
            set { _MaterialStoretoSearch = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialStoretoSearch")); }
        }

        private Models.ProviderCompany _MaterialCompanytoSearch;

        public Models.ProviderCompany MaterialCompanytoSearch
        {
            get { return _MaterialCompanytoSearch; }
            set { _MaterialCompanytoSearch = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialCompanytoSearch")); }
        }


        public void MyCompanysearchkeyup(string text)
        {
            if (text != "")
            {
                ListofCompanies = new ObservableCollection<Models.ProviderCompany>(MyWorkerforSearchkeydowncompany.MyProviderCompaniesRep.find(x => x.NameofCompany.Contains(text)));
            }
            else
            {
                ListofCompanies = new ObservableCollection<Models.ProviderCompany>(MyWorkerforSearchkeydowncompany.MyProviderCompaniesRep.GetAll());
            }

        }
        
            public void MyInventorysearchkeyup(string text)
        {
            if (text != "")
            {
                NameOFStores = new ObservableCollection<Models.Inventory>(MyWorkerforSearchkeydowninventory.MyInventoriesRep.find(x => x.Name.Contains(text)));
            }
            else
            {
                NameOFStores = new ObservableCollection<Models.Inventory>(MyWorkerforSearchkeydowninventory.MyInventoriesRep.GetAll());
            }

        }

        public AbstractMaterialReport MyAbstractMaterialReport { get; set; }
        public class AbstractMaterialReport
        {
            public string Name { get; set; }
            public int RemainedNumberInSearch { get; set; }
            public int RemainedNumber { get; set; }
        }
        private ObservableCollection<AbstractMaterialReport> _MyListofAbstractMaterialsReport;

        public ObservableCollection<AbstractMaterialReport> MyListofAbstractMaterialsReport
        {
            get { return _MyListofAbstractMaterialsReport; }
            set { _MyListofAbstractMaterialsReport = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyListofAbstractMaterialsReport")); }
        }
        public void MyMaterialsearchkeyup(string text)
        {
            getnameofMaterialsGrouped(text);

        }

        private Models.Material _SearchedMaterialDetails;

        public Models.Material SearchedMaterialDetails
        {
            get { return  _SearchedMaterialDetails; }
            set {  _SearchedMaterialDetails = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchedMaterialDetails")); }
        }

        public AbstractMaterial MyAbstractMaterial { get; set; }
        public class AbstractMaterial
        {
            public string Name { get; set; }
            public int RemainedNumberInSearch { get; set; }
            public int RemainedNumber { get; set; }
        }
        private ObservableCollection<AbstractMaterial> _MyListofAbstractMaterials;

        public ObservableCollection<AbstractMaterial> MyListofAbstractMaterials
        {
            get { return _MyListofAbstractMaterials; }
            set { _MyListofAbstractMaterials = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyListofAbstractMaterials")); }
        }
        public ObservableCollection<Models.Material> _listofSearchedMaterials { get; set; }
        public ObservableCollection<Models.Material> listofSearchedMaterials
        {
            get
            {
                return _listofSearchedMaterials;
            }
            set
            {
                _listofSearchedMaterials = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("listofSearchedMaterials"));
            }
        }
        private Models.Inventory _MyInventory;

        public Models.Inventory MyInventory
        {
            get { return _MyInventory; }
            set { _MyInventory = value;NewMaterial.MaterialInventoryid = (value!=null)?value.Id:-1; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyInventory")); }
        }

        private Models.ProviderCompany _MyCompany;

        public Models.ProviderCompany MyCompany
        {
            get { return _MyCompany; }
            set { _MyCompany = value;NewMaterial.MaterialCompanyid =(value!=null)?value.Id:-1; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyCompany")); }
        }
        public void OpenDetailsofMaterialBuying(object sen, RoutedEventArgs e)
        {
            UnitOfWork uni = new UnitOfWork(ctx);
            List<Models.Material> mats = new List<Models.Material>();
            foreach(var x in RefrenceAfterSearch)
            {
                if(x.Key== ((Button)sen).CommandParameter)
                {
                    foreach(var x1 in x)
                    {
                        mats.Add(x1);
                    }
                }
            }
            //listofSearchedMaterials = new ObservableCollection<Models.Material>(uni.MyMaterialsRep.find(x=>x.Name==((Button)sen).CommandParameter).Where(x=>Convert.ToInt32(x.NumberofMaterial)>0));
            listofSearchedMaterials = new ObservableCollection<Models.Material>(mats.Where(x => Convert.ToInt32(x.NumberofMaterial) > 0));
            mysearchnewmaterial.MySubSearchPageView.DitailsofofMaterialBuyingDialog.IsOpen = true;
        }
        public void OpenDetailsofMaterialBuyingInReport(object sen, RoutedEventArgs e)
        {
            try
            {
                UnitOfWork uni = new UnitOfWork(ctx);
                List<Models.Material> mats = new List<Models.Material>();
                foreach (var x in RefrenceAfterSearch)
                {
                    if (x.Key == ((Button)sen).CommandParameter)
                    {
                        foreach (var x1 in x)
                        {
                            mats.Add(x1);
                        }
                    }
                }
                //listofSearchedMaterials = new ObservableCollection<Models.Material>(uni.MyMaterialsRep.find(x=>x.Name==((Button)sen).CommandParameter).Where(x=>Convert.ToInt32(x.NumberofMaterial)>0));
                listofSearchedMaterials = new ObservableCollection<Models.Material>(mats.Where(x => Convert.ToInt32(x.NumberofMaterial) > 0));
                mysearchnewmaterial.MySubReportPageView.DitailsofofMaterialBuyingDialog.IsOpen = true;
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        public void closeDitailsofofMaterialBuyingDialog(object sen, RoutedEventArgs e)
        {
            listofSearchedMaterials = null;
            mysearchnewmaterial.MySubSearchPageView.DitailsofofMaterialBuyingDialog.IsOpen = false;
        }
        public void closeDitailsofofMaterialBuyingDialogInReport(object sen, RoutedEventArgs e)
        {
            listofSearchedMaterials = null;
            mysearchnewmaterial.MySubReportPageView.DitailsofofMaterialBuyingDialog.IsOpen = false;
        }
        public void closeMoreDitailsofofMaterialBuyingDialog(object sen, RoutedEventArgs e)
        {
            mysearchnewmaterial.MySubSearchPageView.MoreDitailsofofMaterialBuyingDialog.IsOpen = false;
        }
        public void closeMoreDitailsofofMaterialBuyingDialogInReport(object sen, RoutedEventArgs e)
        {
            mysearchnewmaterial.MySubReportPageView.MoreDitailsofofMaterialBuyingDialog.IsOpen = false;
        }
        private Models.Material _MatrialToExit;

        public Models.Material MatrialToExit
        {
            get { return _MatrialToExit; }
            set { _MatrialToExit = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MatrialToExit")); }
        }
        private bool _IsPayedReport;

        public bool IsPayedReport
        {
            get { return _IsPayedReport;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsPayedReport")); }
            set { _IsPayedReport = value; }
        }
        private bool _IsPayedReportIncluded;

        public bool IsPayedReportIncluded
        {
            get { return _IsPayedReportIncluded; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsPayedReportIncluded")); }
            set { _IsPayedReportIncluded = value; }
        }
        private bool _IsFinishingReport;

        public bool IsFinishingReport
        {
            get { return _IsFinishingReport; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsFinishingReport")); }
            set { _IsFinishingReport = value; }
        }
        private bool _IsFinishingReportIncluded;

        public bool IsFinishingReportIncluded
        {
            get { return _IsFinishingReportIncluded; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsFinishingReportIncluded")); }
            set { _IsFinishingReportIncluded = value; }
        }
        public void OpenMoreDitailsofofMaterialBuyingDialog(object sen, RoutedEventArgs earg)
        {
            try
            {
                UnitOfWork uni = new UnitOfWork(ctx);
                ListofSearchedMaterialsMoreDetails = new ObservableCollection<Models.Material>(uni.MyMaterialsRep.find(x => x.Id.ToString() == ((Button)sen).CommandParameter.ToString()));
                NewMaterial = ListofSearchedMaterialsMoreDetails.FirstOrDefault<Models.Material>();
                MyInventory = NameOFStores.Where(x => x.Id == NewMaterial.MaterialInventoryid).FirstOrDefault<Models.Inventory>();
                MyCompany = ListofCompanies.Where(x => x.Id == NewMaterial.MaterialCompanyid).FirstOrDefault<Models.ProviderCompany>();
                MyNumofMaterial = NewMaterial.NumberofMaterial;
                testNewMaterialName = NewMaterial.Name;
                mysearchnewmaterial.MySubSearchPageView.MoreDitailsofofMaterialBuyingDialog.IsOpen = true;
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        public void OpenMoreDitailsofofMaterialBuyingDialogInReport(object sen, RoutedEventArgs earg)
        {
            try
            {
                UnitOfWork uni = new UnitOfWork(ctx);
                ListofSearchedMaterialsMoreDetails = new ObservableCollection<Models.Material>(uni.MyMaterialsRep.find(x => x.Id.ToString() == ((Button)sen).CommandParameter.ToString()));
                NewMaterial = ListofSearchedMaterialsMoreDetails.FirstOrDefault<Models.Material>();
                MyInventory = NameOFStores.Where(x => x.Id == NewMaterial.MaterialInventoryid).FirstOrDefault<Models.Inventory>();
                MyCompany = ListofCompanies.Where(x => x.Id == NewMaterial.MaterialCompanyid).FirstOrDefault<Models.ProviderCompany>();
                MyNumofMaterial = NewMaterial.NumberofMaterial;
                testNewMaterialName = NewMaterial.Name;
                mysearchnewmaterial.MySubReportPageView.MoreDitailsofofMaterialBuyingDialog.IsOpen = true;
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        private string _PrivateNumber;

        public string PrivateNumber
        {
            get { return _PrivateNumber; }
            set { _PrivateNumber = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PrivateNumber")); }
        }
        private string _PublicNumber;

        public string PublicNumber
        {
            get { return _PublicNumber; }
            set 
            { 
                _PublicNumber = value;
                MatrialToExit.NumberofMaterial = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PublicNumber"));
            }
        }
        public void OpenExitMaterialDialogGeneral(object sen,RoutedEventArgs e)
        {
            try
            {
                UnitOfWork uni = new UnitOfWork(ctx);
                Models.Material tt = uni.MyMaterialsRep.find(x => x.Name == ((Button)sen).CommandParameter.ToString()).Where(x=>x.NumberofMaterial!="-45").FirstOrDefault();
                MatrialToExit.Name = tt.Name;
                MatrialToExit.MaterialImage = tt.MaterialImage;
                MatrialToExit.PrivateNumberofMaterial = tt.RemainedNumber.ToString();
                MatrialToExit.InstalledLocation = "General";
                MatrialToExit.MaterialGiverToUserMain = ""; MatrialToExit.MaterialGiverToUserSecondary = "";
                MatrialToExit.MaterialUser = "";
                mysearchnewmaterial.MySubSearchPageView.ExitMaterialDialog.IsOpen = true;
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        public void OpenExitMaterialDialogParticular(object sen, RoutedEventArgs e)
        {
            try
            {
                UnitOfWork uni = new UnitOfWork(ctx);
                Models.Material tt = uni.MyMaterialsRep.find(x => x.Id.ToString() == ((Button)sen).CommandParameter.ToString()).FirstOrDefault();
                MatrialToExit.Name = tt.Name;
                MatrialToExit.MaterialImage = tt.MaterialImage;
                MatrialToExit.PrivateNumberofMaterial = tt.NumberofMaterial.ToString();
                MatrialToExit.InstalledLocation = "Particular";
                MatrialToExit.IsAccessory = tt.Id;
                MatrialToExit.MaterialGiverToUserMain = "";MatrialToExit.MaterialGiverToUserSecondary = "";
                MatrialToExit.MaterialUser = "";
                mysearchnewmaterial.MySubSearchPageView.ExitMaterialDialog.IsOpen = true;
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }

        public bool MyApplyChangesInExitMaterialDialogCanExecute(object parm)
        {
            int res, res1;
            if (MatrialToExit != null)
            {
                if (int.TryParse(MatrialToExit.PrivateNumberofMaterial, out res1))
                {
                    if (int.TryParse(PublicNumber, out res))
                    {
                        if (res <= res1)
                        {
                            if (!string.IsNullOrEmpty(MatrialToExit.DateofExitofStore) && !string.IsNullOrEmpty(MatrialToExit.MaterialUserRequestNumber.ToString())
                                && !string.IsNullOrEmpty(MatrialToExit.MaterialUser) && !string.IsNullOrEmpty(MatrialToExit.MaterialGiverToUserMain)
                                && !string.IsNullOrEmpty(MatrialToExit.MaterialGiverToUserSecondary) && res > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MainMessageQueue1.Enqueue("اشکالی در سیستم وجود دارد با ادمین تماس بگیرید");
                MainSnackIsActive1 = true;
                return false;
            }
        }
        public void MyApplyChangesInExitMaterialDialogExecute(object parm)
        {
            try
            {
                UnitOfWork uni = new UnitOfWork(ctx);
                if (MatrialToExit.InstalledLocation == "General")
                {
                    List<Models.Material> mats = uni.MyMaterialsRep.find(x => x.Name == MatrialToExit.Name).Where(x => Convert.ToInt32(x.NumberofMaterial) > 0).ToList();
                    int res1; int refres1;
                    if (int.TryParse(MatrialToExit.NumberofMaterial, out res1))
                    {
                        refres1 = res1;
                        for (int i = 0; i < mats.Count; i++)
                        {
                            int res;
                            if (int.TryParse(mats[i].NumberofMaterial, out res))
                            {
                                if (res < res1)
                                {
                                    mats[i].NumberofMaterial = "0";
                                    mats[i].MaterialUserRequestNumber = MatrialToExit.MaterialUserRequestNumber;
                                    mats[i].MaterialUser = MatrialToExit.MaterialUser;
                                    mats[i].MaterialGiverToUserSecondary = MatrialToExit.MaterialGiverToUserSecondary;
                                    mats[i].MaterialGiverToUserMain = MatrialToExit.MaterialGiverToUserMain;
                                    mats[i].DateofEntrancetoStore = MatrialToExit.DateofEntrancetoStore;
                                    mats[i].TimeofEntrancetoStore = MatrialToExit.TimeofEntrancetoStore;
                                    mats[i].DateofExitofStore = MatrialToExit.DateofExitofStore;
                                    mats[i].TimeofExitofStore = MatrialToExit.TimeofExitofStore;
                                    mats[i].OtherDetails = MatrialToExit.OtherDetails;
                                    uni.MyMaterialsRep.Add(mats[i]);
                                    ctx.Entry(mats[i]).State = System.Data.Entity.EntityState.Modified;
                                    res1 -= res;
                                    if (res1 <= 0)
                                    {
                                        for (int ii = 0; ii < mats.Count; ii++)
                                        {
                                            mats[ii].RemainedNumber -= refres1;
                                        };
                                        var yy = from b in mats group b by b.Name into newout select newout;
                                        MyListofAbstractMaterials.Clear();
                                        foreach (var x in yy)
                                        {
                                            foreach (var x1 in x)
                                            {
                                                MyListofAbstractMaterials.Add(new AbstractMaterial() { Name = x.Key, RemainedNumber = x1.RemainedNumber });
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    continue;
                                }
                                else if (res1 == res)
                                {
                                    mats[i].NumberofMaterial = "0";
                                    mats[i].MaterialUserRequestNumber = MatrialToExit.MaterialUserRequestNumber;
                                    mats[i].MaterialUser = MatrialToExit.MaterialUser;
                                    mats[i].MaterialGiverToUserSecondary = MatrialToExit.MaterialGiverToUserSecondary;
                                    mats[i].MaterialGiverToUserMain = MatrialToExit.MaterialGiverToUserMain;
                                    mats[i].DateofEntrancetoStore = MatrialToExit.DateofEntrancetoStore;
                                    mats[i].TimeofEntrancetoStore = MatrialToExit.TimeofEntrancetoStore;
                                    mats[i].DateofExitofStore = MatrialToExit.DateofExitofStore;
                                    mats[i].TimeofExitofStore = MatrialToExit.TimeofExitofStore;
                                    mats[i].OtherDetails = MatrialToExit.OtherDetails;
                                    uni.MyMaterialsRep.Add(mats[i]);
                                    ctx.Entry(mats[i]).State = System.Data.Entity.EntityState.Modified;
                                    for (int ii = 0; ii < mats.Count; ii++)
                                    {
                                        mats[ii].RemainedNumber -= refres1;
                                    }
                                    var yy = from b in mats group b by b.Name into newout select newout;
                                    MyListofAbstractMaterials.Clear();
                                    foreach (var x in yy)
                                    {
                                        foreach (var x1 in x)
                                        {
                                            MyListofAbstractMaterials.Add(new AbstractMaterial() { Name = x.Key, RemainedNumber = x1.RemainedNumber });
                                            break;
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    Models.Material splittedmaterial = (Models.Material)mats[i].Clone();
                                    splittedmaterial.PrivateNumberofMaterial = res1.ToString();
                                    splittedmaterial.NumberofMaterial = "0";
                                    splittedmaterial.MaterialUserRequestNumber = MatrialToExit.MaterialUserRequestNumber;
                                    splittedmaterial.MaterialUser = MatrialToExit.MaterialUser;
                                    splittedmaterial.MaterialGiverToUserSecondary = MatrialToExit.MaterialGiverToUserSecondary;
                                    splittedmaterial.MaterialGiverToUserMain = MatrialToExit.MaterialGiverToUserMain;
                                    splittedmaterial.DateofEntrancetoStore = MatrialToExit.DateofEntrancetoStore;
                                    splittedmaterial.TimeofEntrancetoStore = MatrialToExit.TimeofEntrancetoStore;
                                    splittedmaterial.DateofExitofStore = MatrialToExit.DateofExitofStore;
                                    splittedmaterial.TimeofExitofStore = MatrialToExit.TimeofExitofStore;
                                    splittedmaterial.OtherDetails = MatrialToExit.OtherDetails;
                                    splittedmaterial.RefId = mats[i].Id;
                                    uni.MyMaterialsRep.Add(splittedmaterial);
                                    mats[i].NumberofMaterial = (res - res1).ToString();
                                    mats[i].MaterialUserRequestNumber = MatrialToExit.MaterialUserRequestNumber;
                                    mats[i].MaterialUser = MatrialToExit.MaterialUser;
                                    mats[i].MaterialGiverToUserSecondary = MatrialToExit.MaterialGiverToUserSecondary;
                                    mats[i].MaterialGiverToUserMain = MatrialToExit.MaterialGiverToUserMain;
                                    mats[i].DateofEntrancetoStore = MatrialToExit.DateofEntrancetoStore;
                                    mats[i].TimeofEntrancetoStore = MatrialToExit.TimeofEntrancetoStore;
                                    mats[i].DateofExitofStore = MatrialToExit.DateofExitofStore;
                                    mats[i].TimeofExitofStore = MatrialToExit.TimeofExitofStore;
                                    mats[i].OtherDetails = MatrialToExit.OtherDetails;
                                    uni.MyMaterialsRep.Add(mats[i]);
                                    ctx.Entry(mats[i]).State = System.Data.Entity.EntityState.Modified;
                                    for (int ii = 0; ii < mats.Count; ii++)
                                    {
                                        mats[ii].RemainedNumber -= refres1;
                                    }
                                    var yy = from b in mats group b by b.Name into newout select newout;
                                    MyListofAbstractMaterials.Clear();
                                    foreach (var x in yy)
                                    {
                                        foreach (var x1 in x)
                                        {
                                            MyListofAbstractMaterials.Add(new AbstractMaterial() { Name = x.Key, RemainedNumber = x1.RemainedNumber });
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }

                        }
                    }
                    MatrialToExit.MaterialUser = ""; MatrialToExit.DateofExitofStore = "";
                    MatrialToExit.MaterialGiverToUserMain = ""; MatrialToExit.MaterialGiverToUserSecondary = "";
                    MatrialToExit.MaterialUserRequestNumber = 0; PublicNumber = "";
                    MatrialToExit.OtherDetails = ""; MatrialToExit.TimeofExitofStore = "";
                    uni.complete();
                    executeGetSearchDetails();
                    ExecuteCreateReport();
                }
                else if (MatrialToExit.InstalledLocation == "Particular")
                {
                    Models.Material mat = uni.MyMaterialsRep.find(x => x.Id == MatrialToExit.IsAccessory).FirstOrDefault<Models.Material>();
                    List<Models.Material> mats = uni.MyMaterialsRep.find(x => x.Name == MatrialToExit.Name).Where(x=>x.NumberofMaterial!="-45").ToList();

                    int res1; int refres1;
                    if (int.TryParse(MatrialToExit.NumberofMaterial, out res1))
                    {
                        refres1 = res1;
                        int res;
                        if (int.TryParse(mat.NumberofMaterial, out res))
                        {
                            if (res == res1)
                            {
                                mat.NumberofMaterial = (res - res1).ToString();
                                mat.MaterialUserRequestNumber = MatrialToExit.MaterialUserRequestNumber;
                                mat.MaterialUser = MatrialToExit.MaterialUser;
                                mat.MaterialGiverToUserSecondary = MatrialToExit.MaterialGiverToUserSecondary;
                                mat.MaterialGiverToUserMain = MatrialToExit.MaterialGiverToUserMain;
                                mat.DateofEntrancetoStore = MatrialToExit.DateofEntrancetoStore;
                                mat.TimeofEntrancetoStore = MatrialToExit.TimeofEntrancetoStore;
                                mat.DateofExitofStore = MatrialToExit.DateofExitofStore;
                                mat.TimeofExitofStore = MatrialToExit.TimeofExitofStore;
                                mat.OtherDetails = MatrialToExit.OtherDetails;
                                uni.MyMaterialsRep.Add(mat);
                                ctx.Entry(mat).State = System.Data.Entity.EntityState.Modified;
                                for (int ii = 0; ii < mats.Count; ii++)
                                {
                                    mats[ii].RemainedNumber -= refres1;
                                }
                                listofSearchedMaterials = new ObservableCollection<Models.Material>(uni.MyMaterialsRep.find(x => x.Name == MatrialToExit.Name).Where(x => Convert.ToInt32(x.NumberofMaterial) > 0));
                            }
                            else if (res > res1)
                            {
                                Models.Material splittedmaterial = (Models.Material)mat.Clone();
                                splittedmaterial.PrivateNumberofMaterial = res1.ToString();
                                splittedmaterial.NumberofMaterial = "0";
                                splittedmaterial.MaterialUserRequestNumber = MatrialToExit.MaterialUserRequestNumber;
                                splittedmaterial.MaterialUser = MatrialToExit.MaterialUser;
                                splittedmaterial.MaterialGiverToUserSecondary = MatrialToExit.MaterialGiverToUserSecondary;
                                splittedmaterial.MaterialGiverToUserMain = MatrialToExit.MaterialGiverToUserMain;
                                splittedmaterial.DateofEntrancetoStore = MatrialToExit.DateofEntrancetoStore;
                                splittedmaterial.TimeofEntrancetoStore = MatrialToExit.TimeofEntrancetoStore;
                                splittedmaterial.DateofExitofStore = MatrialToExit.DateofExitofStore;
                                splittedmaterial.TimeofExitofStore = MatrialToExit.TimeofExitofStore;
                                splittedmaterial.OtherDetails = MatrialToExit.OtherDetails;
                                splittedmaterial.RefId = mat.Id;
                                uni.MyMaterialsRep.Add(splittedmaterial);
                                mat.NumberofMaterial = (res - res1).ToString();
                                mat.MaterialUserRequestNumber = MatrialToExit.MaterialUserRequestNumber;
                                mat.MaterialUser = MatrialToExit.MaterialUser;
                                mat.MaterialGiverToUserSecondary = MatrialToExit.MaterialGiverToUserSecondary;
                                mat.MaterialGiverToUserMain = MatrialToExit.MaterialGiverToUserMain;
                                mat.DateofEntrancetoStore = MatrialToExit.DateofEntrancetoStore;
                                mat.TimeofEntrancetoStore = MatrialToExit.TimeofEntrancetoStore;
                                mat.DateofExitofStore = MatrialToExit.DateofExitofStore;
                                mat.TimeofExitofStore = MatrialToExit.TimeofExitofStore;
                                mat.OtherDetails = MatrialToExit.OtherDetails;
                                uni.MyMaterialsRep.Add(mat);
                                ctx.Entry(mat).State = System.Data.Entity.EntityState.Modified;
                                for (int ii = 0; ii < mats.Count; ii++)
                                {
                                    mats[ii].RemainedNumber -= refres1;
                                }
                                listofSearchedMaterials = new ObservableCollection<Models.Material>(uni.MyMaterialsRep.find(x => x.Name == MatrialToExit.Name).Where(x => Convert.ToInt32(x.NumberofMaterial) > 0));
                            }
                        }
                    }
                    MatrialToExit.MaterialUser = ""; MatrialToExit.DateofExitofStore = "";
                    MatrialToExit.MaterialGiverToUserMain = ""; MatrialToExit.MaterialGiverToUserSecondary = "";
                    MatrialToExit.MaterialUserRequestNumber = 0; PublicNumber = "";
                    MatrialToExit.OtherDetails = ""; MatrialToExit.TimeofExitofStore = "";
                    uni.complete();
                    executeGetSearchDetails();
                    ExecuteCreateReport();
                }
            }
            catch(Exception ex)
            {
                try
                {
                    if (ctx == null)
                    {
                        ctx = new InventoryApplicationContext();
                    }
                    UnitOfWork un = new UnitOfWork(ctx);
                    un.MyLogsRep.Add(new Models.Log() { LogReport = ex.Message, TimeofLog = DateTime.Now, UserInChargeofReading = ex.StackTrace, classofDevice = null, IsRead = null });
                    un.complete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("خطا در سیستم");
                }
            }
        }
        private Models.Peronel _PeronelForReport;

        public Models.Peronel PeronelForReport
        {
            get { return _PeronelForReport; }
            set { _PeronelForReport = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PeronelForReport")); }
        }

        private ObservableCollection<Models.Peronel> _NameofPersonels;
        public ObservableCollection<Models.Peronel> NameofPersonels
        {
            get { return _NameofPersonels; }
            set { _NameofPersonels = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameofPersonels")); }
        }
        private ObservableCollection<Models.Peronel> _NameofPersonels0;
        public ObservableCollection<Models.Peronel> NameofPersonels0
        {
            get { return _NameofPersonels0; }
            set { _NameofPersonels0 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameofPersonels0")); }
        }
        private ObservableCollection<Models.Peronel> _NameofPersonels1;

        public ObservableCollection<Models.Peronel> NameofPersonels1
        {
            get { return _NameofPersonels1; }
            set { _NameofPersonels1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameofPersonels1")); }
        }
        private ObservableCollection<Models.Peronel> _NameofPersonels2;

        public ObservableCollection<Models.Peronel> NameofPersonels2
        {
            get { return _NameofPersonels2; }
            set { _NameofPersonels2 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameofPersonels2")); }
        }
        private ObservableCollection<Models.Peronel> _NameofPersonels3;

        public ObservableCollection<Models.Peronel> NameofPersonels3
        {
            get { return _NameofPersonels3; }
            set { _NameofPersonels3 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameofPersonels3")); }
        }
        private Models.Peronel _NewPersonel;

        public Models.Peronel NewPersonel
        {
            get { return _NewPersonel; }
            set { _NewPersonel = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewPersonel")); }
        }
        public IEnumerable<Models.Peronel> getNameofPersonels()
        {
            //try
            //{
                UnitOfWork uni = new UnitOfWork(ctx);
                IEnumerable<Models.Peronel> y1 = uni.MyPersonRep.GetAll();
                foreach (Models.Peronel mm in y1)
                {
                    ctx.Entry(mm).Reload();
                }
                List<Models.Peronel> persons = uni.MyPersonRep.GetAll().ToList();
                return persons;
            //}
            //catch(Exception ex)
            //{
            //    return null;
            //}
        }
        public byte[] ConvertToByte(BitmapImage img)
        {

            byte[] data;
            try
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(img));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                    return data;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        private BitmapImage _MyResultImage_personel;

        public BitmapImage MyResultImage_personel
        {
            get { return _MyResultImage_personel; }
            set
            {
                _MyResultImage_personel = value;
                if (NewPersonel != null)
                {
                    NewPersonel.PersonelImage = ConvertToByte(_MyResultImage_personel);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyResultImage_personel"));
            }
        }
        private string _MyImageSourceVisibility_1_personel;

        public string MyImageSourceVisibility_1_personel
        {
            get { return _MyImageSourceVisibility_1_personel; }
            set
            {
                _MyImageSourceVisibility_1_personel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility0_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility2_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility_1_personel"));
            }
        }
        private string _MyImageSourceVisibility0_personel;

        public string MyImageSourceVisibility0_personel
        {
            get { return _MyImageSourceVisibility0_personel; }
            set
            {
                _MyImageSourceVisibility0_personel = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility0_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility2_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility_1_personel"));
            }
        }
        private string _MyImageSourceVisibility1_personel;

        public string MyImageSourceVisibility1_personel
        {
            get { return _MyImageSourceVisibility1_personel; }
            set
            {
                _MyImageSourceVisibility1_personel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility0_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility2_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility_1_personel"));
            }
        }
        private string _MyImageSourceVisibility2_personel;

        public string MyImageSourceVisibility2_personel
        {
            get { return _MyImageSourceVisibility2_personel; }
            set
            {
                _MyImageSourceVisibility2_personel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility1_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility0_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility2_personel"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyImageSourceVisibility_1_personel"));
            }
        }

        private int _MySelectedImgeSourcesPersonel;

        public int MySelectedImgeSourcesPersonel
        {
            get { return _MySelectedImgeSourcesPersonel; }
            set
            {
                _MySelectedImgeSourcesPersonel = value;
                if (value == 0)
                {
                    MyImageSourceVisibility2_personel = "Hidden";
                    MyImageSourceVisibility0_personel = "Hidden";
                    MyImageSourceVisibility1_personel = "Hidden";
                    MyImageSourceVisibility_1_personel = "Visible";
                    using (MemoryStream memory = new MemoryStream())
                    {
                        //string filepath = Path.GetFullPath("../../Assets/Images/unknownman.png");
                        //File.OpenRead(filepath).CopyTo(memory);
                        //memory.Position = 0;
                        BitmapImage bitmapimage = new BitmapImage();
                        bitmapimage.BeginInit();
                        bitmapimage.UriSource = new Uri("/InventoryApplication;component/Assets/Images/unknownman.png", UriKind.Relative);
                        //bitmapimage.StreamSource = memory;
                        //bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapimage.EndInit();
                        bitmapimage.Freeze();
                        MyResultImage_personel = bitmapimage;
                    }
                }
                else if (value == 1)
                {
                    MyImageSourceVisibility_1_personel = "Hidden";
                    MyImageSourceVisibility2_personel = "Hidden";
                    MyImageSourceVisibility0_personel = "Visible";
                    MyImageSourceVisibility1_personel = "Hidden";
                    using (MemoryStream memory = new MemoryStream())
                    {
                        //string filepath = Path.GetFullPath("../../Assets/Images/unknownman.png");
                        //File.OpenRead(filepath).CopyTo(memory);
                        //memory.Position = 0;
                        BitmapImage bitmapimage = new BitmapImage();
                        bitmapimage.BeginInit();
                        bitmapimage.UriSource = new Uri("/InventoryApplication;component/Assets/Images/unknownman.png", UriKind.Relative);
                        //bitmapimage.StreamSource = memory;
                        //bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapimage.EndInit();
                        bitmapimage.Freeze();
                        MyResultImage_personel = bitmapimage;
                    }
                }
                else if (value == 2)
                {
                    MyImageSourceVisibility_1_personel = "Hidden";
                    MyImageSourceVisibility2_personel = "Hidden";
                    MyImageSourceVisibility0_personel = "Hidden";
                    MyImageSourceVisibility1_personel = "Visible";
                }
                else if (value > 2)
                {
                    MyImageSourceVisibility_1_personel = "Hidden";
                    MyImageSourceVisibility2_personel = "Visible";
                    MyImageSourceVisibility1_personel = "Hidden";
                    MyImageSourceVisibility0_personel = "Hidden";
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MySelectedImgeSourcesPersonel"));
            }
        }
        public IEnumerable<IGrouping<string,Models.Material>> RefrenceAfterSearch { get; set; }
        public void executeGetSearchDetails()
        { 
            UnitOfWork myunit = new UnitOfWork(ctx);
            IEnumerable<Models.Material> y1, y2, y3, y4, y5;
            y1 = myunit.MyMaterialsRep.GetAll().Where(x=>x.NumberofMaterial!="-45");
            foreach(Models.Material mm in y1)
            {
                ctx.Entry(mm).Reload();
            }
            MyListofAbstractMaterials = new ObservableCollection<AbstractMaterial>();
            MyListofAbstractMaterials.Clear();
            if (!string.IsNullOrEmpty(MaterialNametoSearch))
            {
                y2 = y1.Where(x => (x.Name != null && x.Name.Contains(MaterialNametoSearch)));
            }
            else
            {
                y2 = y1;
            }
            if (!string.IsNullOrEmpty(MaterialReceipttoSearch))
            {
                y3 = y2.Where(x => x.MaterialReceiptnumber != null).Where(x => x.MaterialReceiptnumber == MaterialReceipttoSearch);
            }
            else
            {
                y3 = y2;
            }
            if (MaterialCompanytoSearch != null && MaterialCompanytoSearch.Id != null && !string.IsNullOrEmpty(MaterialCompanytoSearch.Id.ToString()) && (int)MaterialCompanytoSearch.Id > 0)
            {
                y4 = y3.Where(x => x.MaterialCompanyid != null).Where(x => x.MaterialCompanyid == MaterialCompanytoSearch.Id);
            }
            else
            {
                y4 = y3;
            }
            if (MaterialStoretoSearch != null && MaterialStoretoSearch.Id != null && !string.IsNullOrEmpty(MaterialStoretoSearch.Id.ToString()) && (int)MaterialStoretoSearch.Id > 0)
            {
                y5 = y4.Where(x => x.MaterialInventoryid != null).Where(x => x.MaterialInventoryid == MaterialStoretoSearch.Id);
            }
            else
            {
                y5 = y4;
            }
            if (y5 != null)
            {
                var yy = from b in y5 group b by b.Name into newout select newout;
                RefrenceAfterSearch = yy;
                int RemaindInSearch = 0;
                foreach(var x in yy)
                {
                    int counter = 0;
                    string name;
                    int remainednumber;
                    Models.Material tt= x.AsEnumerable().FirstOrDefault();
                    foreach (var x1 in x)
                    {
                        counter += Convert.ToInt32(x1.NumberofMaterial);
                    }
                    MyListofAbstractMaterials.Add(new AbstractMaterial() { Name = tt.Name, RemainedNumber = tt.RemainedNumber, RemainedNumberInSearch = counter }) ;
                }
            }
        }

    }
}
