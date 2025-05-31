using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_debugappversion : GXProcedure
   {
      public prc_debugappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_debugappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<SdtSDT_PageUrl> aP0_PageUrlList ,
                           out SdtSDT_DebugResult aP1_DebugResults ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV24PageUrlList = aP0_PageUrlList;
         this.AV9DebugResults = new SdtSDT_DebugResult(context) ;
         this.AV10Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_DebugResults=this.AV9DebugResults;
         aP2_Error=this.AV10Error;
      }

      public SdtSDT_Error executeUdp( GXBaseCollection<SdtSDT_PageUrl> aP0_PageUrlList ,
                                      out SdtSDT_DebugResult aP1_DebugResults )
      {
         execute(aP0_PageUrlList, out aP1_DebugResults, out aP2_Error);
         return AV10Error ;
      }

      public void executeSubmit( GXBaseCollection<SdtSDT_PageUrl> aP0_PageUrlList ,
                                 out SdtSDT_DebugResult aP1_DebugResults ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV24PageUrlList = aP0_PageUrlList;
         this.AV9DebugResults = new SdtSDT_DebugResult(context) ;
         this.AV10Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_DebugResults=this.AV9DebugResults;
         aP2_Error=this.AV10Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV34GXV1 = 1;
         while ( AV34GXV1 <= AV24PageUrlList.Count )
         {
            AV22pageUrl = ((SdtSDT_PageUrl)AV24PageUrlList.Item(AV34GXV1));
            AV31PageItem = new SdtSDT_DebugResult_PagesItem(context);
            AV31PageItem.gxTpr_Page = AV22pageUrl.gxTpr_Page;
            AV26UrlCheckItems.Clear();
            AV35GXV2 = 1;
            while ( AV35GXV2 <= AV22pageUrl.gxTpr_Urls.Count )
            {
               AV27pageUrlItem = ((SdtSDT_PageUrl_UrlsItem)AV22pageUrl.gxTpr_Urls.Item(AV35GXV2));
               AV29urlCheckItem = new SdtUrlCheckItem(context);
               AV29urlCheckItem.gxTpr_Url = AV27pageUrlItem.gxTpr_Url;
               AV29urlCheckItem.gxTpr_Affectedtype = AV27pageUrlItem.gxTpr_Affectedtype;
               AV29urlCheckItem.gxTpr_Affectedname = AV27pageUrlItem.gxTpr_Affectedname;
               AV26UrlCheckItems.Add(AV29urlCheckItem, 0);
               AV35GXV2 = (int)(AV35GXV2+1);
            }
            AV18UrlStatuses = AV28UrlChecker.checkurls(AV26UrlCheckItems);
            AV20Summary = AV28UrlChecker.getsummary();
            AV9DebugResults.gxTpr_Summary.gxTpr_Totalurls = (decimal)(AV9DebugResults.gxTpr_Summary.gxTpr_Totalurls+(AV20Summary.gxTpr_Totalurls));
            AV9DebugResults.gxTpr_Summary.gxTpr_Successcount = (decimal)(AV9DebugResults.gxTpr_Summary.gxTpr_Successcount+(AV20Summary.gxTpr_Totalsuccess));
            AV9DebugResults.gxTpr_Summary.gxTpr_Failurecount = (decimal)(AV9DebugResults.gxTpr_Summary.gxTpr_Failurecount+(AV20Summary.gxTpr_Totalfailed));
            AV36GXV3 = 1;
            while ( AV36GXV3 <= AV18UrlStatuses.Count )
            {
               AV21UrlStatus = ((SdtUrlStatus)AV18UrlStatuses.Item(AV36GXV3));
               AV33UrlListItem = new SdtSDT_DebugResult_PagesItem_UrlListItem(context);
               AV33UrlListItem.gxTpr_Url = AV21UrlStatus.gxTpr_Url;
               AV33UrlListItem.gxTpr_Statuscode = StringUtil.Trim( StringUtil.Str( (decimal)(AV21UrlStatus.gxTpr_Statuscode), 9, 0));
               AV33UrlListItem.gxTpr_Statusmessage = AV21UrlStatus.gxTpr_Message;
               AV33UrlListItem.gxTpr_Affectedtype = AV21UrlStatus.gxTpr_Affectedtype;
               AV33UrlListItem.gxTpr_Affectedname = AV21UrlStatus.gxTpr_Affectedname;
               AV31PageItem.gxTpr_Urllist.Add(AV33UrlListItem, 0);
               AV36GXV3 = (int)(AV36GXV3+1);
            }
            AV9DebugResults.gxTpr_Pages.Add(AV31PageItem, 0);
            AV34GXV1 = (int)(AV34GXV1+1);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9DebugResults = new SdtSDT_DebugResult(context);
         AV10Error = new SdtSDT_Error(context);
         AV22pageUrl = new SdtSDT_PageUrl(context);
         AV31PageItem = new SdtSDT_DebugResult_PagesItem(context);
         AV26UrlCheckItems = new GXExternalCollection<SdtUrlCheckItem>( context, "SdtUrlCheckItem", "GeneXus.Programs");
         AV27pageUrlItem = new SdtSDT_PageUrl_UrlsItem(context);
         AV29urlCheckItem = new SdtUrlCheckItem(context);
         AV18UrlStatuses = new GXExternalCollection<SdtUrlStatus>( context, "SdtUrlStatus", "GeneXus.Programs");
         AV28UrlChecker = new SdtUrlChecker(context);
         AV20Summary = new SdtSummary(context);
         AV21UrlStatus = new SdtUrlStatus(context);
         AV33UrlListItem = new SdtSDT_DebugResult_PagesItem_UrlListItem(context);
         /* GeneXus formulas. */
      }

      private int AV34GXV1 ;
      private int AV35GXV2 ;
      private int AV36GXV3 ;
      private GXBaseCollection<SdtSDT_PageUrl> AV24PageUrlList ;
      private SdtSDT_DebugResult AV9DebugResults ;
      private SdtSDT_Error AV10Error ;
      private SdtSDT_PageUrl AV22pageUrl ;
      private SdtSDT_DebugResult_PagesItem AV31PageItem ;
      private GXExternalCollection<SdtUrlCheckItem> AV26UrlCheckItems ;
      private SdtSDT_PageUrl_UrlsItem AV27pageUrlItem ;
      private SdtUrlCheckItem AV29urlCheckItem ;
      private GXExternalCollection<SdtUrlStatus> AV18UrlStatuses ;
      private SdtUrlChecker AV28UrlChecker ;
      private SdtSummary AV20Summary ;
      private SdtUrlStatus AV21UrlStatus ;
      private SdtSDT_DebugResult_PagesItem_UrlListItem AV33UrlListItem ;
      private SdtSDT_DebugResult aP1_DebugResults ;
      private SdtSDT_Error aP2_Error ;
   }

}
