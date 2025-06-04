using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class trn_appversionconversion : GXProcedure
   {
      public trn_appversionconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_appversionconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor TRN_APPVER2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A273Trn_ThemeId = TRN_APPVER2_A273Trn_ThemeId[0];
            n273Trn_ThemeId = TRN_APPVER2_n273Trn_ThemeId[0];
            A622VersionDeletedAt = TRN_APPVER2_A622VersionDeletedAt[0];
            n622VersionDeletedAt = TRN_APPVER2_n622VersionDeletedAt[0];
            A620IsVersionDeleted = TRN_APPVER2_A620IsVersionDeleted[0];
            A11OrganisationId = TRN_APPVER2_A11OrganisationId[0];
            n11OrganisationId = TRN_APPVER2_n11OrganisationId[0];
            A535IsActive = TRN_APPVER2_A535IsActive[0];
            A29LocationId = TRN_APPVER2_A29LocationId[0];
            n29LocationId = TRN_APPVER2_n29LocationId[0];
            A524AppVersionName = TRN_APPVER2_A524AppVersionName[0];
            A523AppVersionId = TRN_APPVER2_A523AppVersionId[0];
            /*
               INSERT RECORD ON TABLE GXA0094

            */
            AV2AppVersionId = A523AppVersionId;
            AV3AppVersionName = A524AppVersionName;
            if ( TRN_APPVER2_n29LocationId[0] )
            {
               AV4LocationId = Guid.Empty;
               nV4LocationId = false;
               nV4LocationId = true;
            }
            else
            {
               AV4LocationId = A29LocationId;
               nV4LocationId = false;
            }
            AV5IsActive = A535IsActive;
            if ( TRN_APPVER2_n11OrganisationId[0] )
            {
               AV6OrganisationId = Guid.Empty;
               nV6OrganisationId = false;
               nV6OrganisationId = true;
            }
            else
            {
               AV6OrganisationId = A11OrganisationId;
               nV6OrganisationId = false;
            }
            AV7IsVersionDeleted = A620IsVersionDeleted;
            if ( TRN_APPVER2_n622VersionDeletedAt[0] )
            {
               AV8VersionDeletedAt = (DateTime)(DateTime.MinValue);
               nV8VersionDeletedAt = false;
               nV8VersionDeletedAt = true;
            }
            else
            {
               AV8VersionDeletedAt = A622VersionDeletedAt;
               nV8VersionDeletedAt = false;
            }
            if ( TRN_APPVER2_n273Trn_ThemeId[0] )
            {
               AV9Trn_ThemeId = Guid.Empty;
            }
            else
            {
               AV9Trn_ThemeId = A273Trn_ThemeId;
            }
            /* Using cursor TRN_APPVER3 */
            pr_default.execute(1, new Object[] {AV2AppVersionId, AV3AppVersionName, nV4LocationId, AV4LocationId, AV5IsActive, nV6OrganisationId, AV6OrganisationId, AV7IsVersionDeleted, nV8VersionDeletedAt, AV8VersionDeletedAt, AV9Trn_ThemeId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0094");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         TRN_APPVER2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         TRN_APPVER2_n273Trn_ThemeId = new bool[] {false} ;
         TRN_APPVER2_A622VersionDeletedAt = new DateTime[] {DateTime.MinValue} ;
         TRN_APPVER2_n622VersionDeletedAt = new bool[] {false} ;
         TRN_APPVER2_A620IsVersionDeleted = new bool[] {false} ;
         TRN_APPVER2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_APPVER2_n11OrganisationId = new bool[] {false} ;
         TRN_APPVER2_A535IsActive = new bool[] {false} ;
         TRN_APPVER2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_APPVER2_n29LocationId = new bool[] {false} ;
         TRN_APPVER2_A524AppVersionName = new string[] {""} ;
         TRN_APPVER2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A273Trn_ThemeId = Guid.Empty;
         A622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A524AppVersionName = "";
         A523AppVersionId = Guid.Empty;
         AV2AppVersionId = Guid.Empty;
         AV3AppVersionName = "";
         AV4LocationId = Guid.Empty;
         AV6OrganisationId = Guid.Empty;
         AV8VersionDeletedAt = (DateTime)(DateTime.MinValue);
         AV9Trn_ThemeId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appversionconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_APPVER2_A273Trn_ThemeId, TRN_APPVER2_n273Trn_ThemeId, TRN_APPVER2_A622VersionDeletedAt, TRN_APPVER2_n622VersionDeletedAt, TRN_APPVER2_A620IsVersionDeleted, TRN_APPVER2_A11OrganisationId, TRN_APPVER2_n11OrganisationId, TRN_APPVER2_A535IsActive, TRN_APPVER2_A29LocationId, TRN_APPVER2_n29LocationId,
               TRN_APPVER2_A524AppVersionName, TRN_APPVER2_A523AppVersionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0094 ;
      private string Gx_emsg ;
      private DateTime A622VersionDeletedAt ;
      private DateTime AV8VersionDeletedAt ;
      private bool n273Trn_ThemeId ;
      private bool n622VersionDeletedAt ;
      private bool A620IsVersionDeleted ;
      private bool n11OrganisationId ;
      private bool A535IsActive ;
      private bool n29LocationId ;
      private bool nV4LocationId ;
      private bool AV5IsActive ;
      private bool nV6OrganisationId ;
      private bool AV7IsVersionDeleted ;
      private bool nV8VersionDeletedAt ;
      private string A524AppVersionName ;
      private string AV3AppVersionName ;
      private Guid A273Trn_ThemeId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A523AppVersionId ;
      private Guid AV2AppVersionId ;
      private Guid AV4LocationId ;
      private Guid AV6OrganisationId ;
      private Guid AV9Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_APPVER2_A273Trn_ThemeId ;
      private bool[] TRN_APPVER2_n273Trn_ThemeId ;
      private DateTime[] TRN_APPVER2_A622VersionDeletedAt ;
      private bool[] TRN_APPVER2_n622VersionDeletedAt ;
      private bool[] TRN_APPVER2_A620IsVersionDeleted ;
      private Guid[] TRN_APPVER2_A11OrganisationId ;
      private bool[] TRN_APPVER2_n11OrganisationId ;
      private bool[] TRN_APPVER2_A535IsActive ;
      private Guid[] TRN_APPVER2_A29LocationId ;
      private bool[] TRN_APPVER2_n29LocationId ;
      private string[] TRN_APPVER2_A524AppVersionName ;
      private Guid[] TRN_APPVER2_A523AppVersionId ;
   }

   public class trn_appversionconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTRN_APPVER2;
          prmTRN_APPVER2 = new Object[] {
          };
          Object[] prmTRN_APPVER3;
          prmTRN_APPVER3 = new Object[] {
          new ParDef("AV2AppVersionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3AppVersionName",GXType.VarChar,100,0) ,
          new ParDef("AV4LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV5IsActive",GXType.Boolean,4,0) ,
          new ParDef("AV6OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV7IsVersionDeleted",GXType.Boolean,4,0) ,
          new ParDef("AV8VersionDeletedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AV9Trn_ThemeId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_APPVER2", "SELECT Trn_ThemeId, VersionDeletedAt, IsVersionDeleted, OrganisationId, IsActive, LocationId, AppVersionName, AppVersionId FROM Trn_AppVersion ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_APPVER2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_APPVER3", "INSERT INTO GXA0094(AppVersionId, AppVersionName, LocationId, IsActive, OrganisationId, IsVersionDeleted, VersionDeletedAt, Trn_ThemeId) VALUES(:AV2AppVersionId, :AV3AppVersionName, :AV4LocationId, :AV5IsActive, :AV6OrganisationId, :AV7IsVersionDeleted, :AV8VersionDeletedAt, :AV9Trn_ThemeId)", GxErrorMask.GX_NOMASK,prmTRN_APPVER3)
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((Guid[]) buf[8])[0] = rslt.getGuid(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[11])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
