//using Agava.WebUtility;
//using Agava.YandexGames;
//using System.Collections;

//#pragma warning disable CS0162 // ��������� ������������ ���

//namespace CrazyRacing.Model
//{
//    public class YandexSdk : Sdk
//    {
//        private IEnumerator Start()
//        {
//#if !UNITY_WEBGL || UNITY_EDITOR
//            Init();
//            yield break;
//#endif

//            yield return YandexGamesSdk.Initialize(Init);
//        }

//        public override void ShowInterstitialAd()
//        {
//            InterstitialAd.Show(OnOpenAd, OnCloseInterstitialAd, OnErrorInterstitialAd);
//        }

//        public override void ShowVideoAd()
//        {
//            VideoAd.Show(OnOpenAd, OnRewarded, OnCloseVideoAd, OnErrorInterstitialAd);
//        }

//        protected override void Init()
//        {
//            ChangeLanguage();
//            IdentifyDevice();
//            OnInitialized();
//        }

//        protected override ILanguage GetLanguage()
//        {
//#if !UNITY_WEBGL || UNITY_EDITOR
//            return null;
//#endif

//            string languageCode = YandexGamesSdk.Environment.i18n.lang;
//            LanguageFactory languageFactory = new LanguageFactory();

//            return languageFactory.GetLanguage(languageCode);
//        }

//        protected override void IdentifyDevice()
//        {
//#if !UNITY_WEBGL || UNITY_EDITOR
//            return;
//#endif

//            IsMobile = Device.IsMobile;
//        }
//    }
//}
