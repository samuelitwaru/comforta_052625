using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class prc_gettranslation : GXProcedure
   {
      public prc_gettranslation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_gettranslation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_primaryKey ,
                           out string aP1_Translation )
      {
         this.AV10primaryKey = aP0_primaryKey;
         this.AV9Translation = "" ;
         initialize();
         ExecuteImpl();
         aP1_Translation=this.AV9Translation;
      }

      public string executeUdp( Guid aP0_primaryKey )
      {
         execute(aP0_primaryKey, out aP1_Translation);
         return AV9Translation ;
      }

      public void executeSubmit( Guid aP0_primaryKey ,
                                 out string aP1_Translation )
      {
         this.AV10primaryKey = aP0_primaryKey;
         this.AV9Translation = "" ;
         SubmitImpl();
         aP1_Translation=this.AV9Translation;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13Language = context.GetLanguage( );
         /* Using cursor P00E72 */
         pr_default.execute(0, new Object[] {AV10primaryKey});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A580DynamicTranslationPrimaryKey = P00E72_A580DynamicTranslationPrimaryKey[0];
            A582DynamicTranslationEnglish = P00E72_A582DynamicTranslationEnglish[0];
            A583DynamicTranslationDutch = P00E72_A583DynamicTranslationDutch[0];
            A578DynamicTranslationId = P00E72_A578DynamicTranslationId[0];
            if ( StringUtil.StrCmp(AV13Language, "English") == 0 )
            {
               AV9Translation = A582DynamicTranslationEnglish;
            }
            else if ( StringUtil.StrCmp(AV13Language, "Dutch") == 0 )
            {
               AV9Translation = A583DynamicTranslationDutch;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV9Translation = "";
         AV13Language = "";
         P00E72_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00E72_A582DynamicTranslationEnglish = new string[] {""} ;
         P00E72_A583DynamicTranslationDutch = new string[] {""} ;
         P00E72_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A582DynamicTranslationEnglish = "";
         A583DynamicTranslationDutch = "";
         A578DynamicTranslationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_gettranslation__default(),
            new Object[][] {
                new Object[] {
               P00E72_A580DynamicTranslationPrimaryKey, P00E72_A582DynamicTranslationEnglish, P00E72_A583DynamicTranslationDutch, P00E72_A578DynamicTranslationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV9Translation ;
      private string A582DynamicTranslationEnglish ;
      private string A583DynamicTranslationDutch ;
      private string AV13Language ;
      private Guid AV10primaryKey ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00E72_A580DynamicTranslationPrimaryKey ;
      private string[] P00E72_A582DynamicTranslationEnglish ;
      private string[] P00E72_A583DynamicTranslationDutch ;
      private Guid[] P00E72_A578DynamicTranslationId ;
      private string aP1_Translation ;
   }

   public class prc_gettranslation__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00E72;
          prmP00E72 = new Object[] {
          new ParDef("AV10primaryKey",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E72", "SELECT DynamicTranslationPrimaryKey, DynamicTranslationEnglish, DynamicTranslationDutch, DynamicTranslationId FROM Trn_DynamicTranslation WHERE DynamicTranslationPrimaryKey = :AV10primaryKey ORDER BY DynamicTranslationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E72,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
