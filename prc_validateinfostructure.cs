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
   public class prc_validateinfostructure : GXProcedure
   {
      public prc_validateinfostructure( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_validateinfostructure( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref SdtSDT_InfoContent aP0_SDT_InfoContent )
      {
         this.AV11SDT_InfoContent = aP0_SDT_InfoContent;
         initialize();
         ExecuteImpl();
         aP0_SDT_InfoContent=this.AV11SDT_InfoContent;
      }

      public SdtSDT_InfoContent executeUdp( )
      {
         execute(ref aP0_SDT_InfoContent);
         return AV11SDT_InfoContent ;
      }

      public void executeSubmit( ref SdtSDT_InfoContent aP0_SDT_InfoContent )
      {
         this.AV11SDT_InfoContent = aP0_SDT_InfoContent;
         SubmitImpl();
         aP0_SDT_InfoContent=this.AV11SDT_InfoContent;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV11SDT_InfoContent.gxTpr_Infocontent.Count )
         {
            AV9InfoContent = ((SdtSDT_InfoContent_InfoContentItem)AV11SDT_InfoContent.gxTpr_Infocontent.Item(AV12GXV1));
            if ( StringUtil.StrCmp(AV9InfoContent.gxTpr_Infotype, "Cta") == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon)) )
               {
                  AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabuttonicon = AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctatype;
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor))) )
               {
                  AV9InfoContent.gxTpr_Ctaattributes.gxTpr_Ctabgcolor = context.GetMessage( "ctaColor1", "");
               }
            }
            else
            {
            }
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV9InfoContent = new SdtSDT_InfoContent_InfoContentItem(context);
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private SdtSDT_InfoContent AV11SDT_InfoContent ;
      private SdtSDT_InfoContent aP0_SDT_InfoContent ;
      private SdtSDT_InfoContent_InfoContentItem AV9InfoContent ;
   }

}
