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
   public class prc_savepagev2 : GXProcedure
   {
      public prc_savepagev2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_savepagev2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_PageId ,
                           string aP2_PageName ,
                           string aP3_PageType ,
                           string aP4_PageStructure ,
                           out SdtSDT_Error aP5_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV14PageId = aP1_PageId;
         this.AV15PageName = aP2_PageName;
         this.AV17PageType = aP3_PageType;
         this.AV16PageStructure = aP4_PageStructure;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP5_SDT_Error=this.AV8SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      Guid aP1_PageId ,
                                      string aP2_PageName ,
                                      string aP3_PageType ,
                                      string aP4_PageStructure )
      {
         execute(aP0_AppVersionId, aP1_PageId, aP2_PageName, aP3_PageType, aP4_PageStructure, out aP5_SDT_Error);
         return AV8SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_PageId ,
                                 string aP2_PageName ,
                                 string aP3_PageType ,
                                 string aP4_PageStructure ,
                                 out SdtSDT_Error aP5_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV14PageId = aP1_PageId;
         this.AV15PageName = aP2_PageName;
         this.AV17PageType = aP3_PageType;
         this.AV16PageStructure = aP4_PageStructure;
         this.AV8SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP5_SDT_Error=this.AV8SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV8SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV8SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         GXt_char1 = "";
         new prc_getloggedinuserid(context ).execute( out  GXt_char1) ;
         AV23ReceptionistId = StringUtil.StrToGuid( GXt_char1);
         /* Using cursor P00BG2 */
         pr_default.execute(0, new Object[] {A89ReceptionistId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00BG2_A11OrganisationId[0];
            A29LocationId = P00BG2_A29LocationId[0];
            A89ReceptionistId = P00BG2_A89ReceptionistId[0];
            /* Using cursor P00BG3 */
            pr_default.execute(1, new Object[] {A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A630ToolBoxLastUpdateReceptionistI = P00BG3_A630ToolBoxLastUpdateReceptionistI[0];
               n630ToolBoxLastUpdateReceptionistI = P00BG3_n630ToolBoxLastUpdateReceptionistI[0];
               A632ToolBoxLastUpdateTime = P00BG3_A632ToolBoxLastUpdateTime[0];
               n632ToolBoxLastUpdateTime = P00BG3_n632ToolBoxLastUpdateTime[0];
               A630ToolBoxLastUpdateReceptionistI = AV23ReceptionistId;
               n630ToolBoxLastUpdateReceptionistI = false;
               A632ToolBoxLastUpdateTime = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
               n632ToolBoxLastUpdateTime = false;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P00BG4 */
               pr_default.execute(2, new Object[] {n630ToolBoxLastUpdateReceptionistI, A630ToolBoxLastUpdateReceptionistI, n632ToolBoxLastUpdateTime, A632ToolBoxLastUpdateTime, A29LocationId, A11OrganisationId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
               if (true) break;
               /* Using cursor P00BG5 */
               pr_default.execute(3, new Object[] {n630ToolBoxLastUpdateReceptionistI, A630ToolBoxLastUpdateReceptionistI, n632ToolBoxLastUpdateTime, A632ToolBoxLastUpdateTime, A29LocationId, A11OrganisationId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00BG6 */
         pr_default.execute(4, new Object[] {AV9AppVersionId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A523AppVersionId = P00BG6_A523AppVersionId[0];
            /* Using cursor P00BG7 */
            pr_default.execute(5, new Object[] {A523AppVersionId, AV14PageId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               GXTBG5 = 0;
               A516PageId = P00BG7_A516PageId[0];
               A517PageName = P00BG7_A517PageName[0];
               A525PageType = P00BG7_A525PageType[0];
               A518PageStructure = P00BG7_A518PageStructure[0];
               O518PageStructure = A518PageStructure;
               O518PageStructure = A518PageStructure;
               A517PageName = AV15PageName;
               if ( ( ( StringUtil.StrCmp(A525PageType, "Menu") == 0 ) ) || ( ( StringUtil.StrCmp(A525PageType, "MyLiving") == 0 ) ) || ( ( StringUtil.StrCmp(A525PageType, "MyService") == 0 ) ) || ( ( StringUtil.StrCmp(A525PageType, "MyCare") == 0 ) ) )
               {
                  AV19SDT_MenuPage.FromJSonString(AV16PageStructure, null);
                  AV10CleanedPageStructure = AV19SDT_MenuPage.ToJSonString(false, true);
               }
               else
               {
                  if ( StringUtil.StrCmp(A525PageType, "Information") == 0 )
                  {
                     AV22SDT_InfoContent.FromJSonString(AV16PageStructure, null);
                     AV10CleanedPageStructure = AV22SDT_InfoContent.ToJSonString(false, true);
                  }
                  else
                  {
                     AV18SDT_ContentPage.FromJSonString(AV16PageStructure, null);
                     AV10CleanedPageStructure = AV18SDT_ContentPage.ToJSonString(false, true);
                  }
               }
               A518PageStructure = AV10CleanedPageStructure;
               if ( ! ( ( StringUtil.StrCmp(O518PageStructure, AV10CleanedPageStructure) == 0 ) ) )
               {
                  GXTBG5 = 1;
               }
               /* Using cursor P00BG8 */
               pr_default.execute(6, new Object[] {A517PageName, A518PageStructure, A523AppVersionId, A516PageId});
               pr_default.close(6);
               pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
               if ( GXTBG5 == 1 )
               {
                  context.CommitDataStores("prc_savepagev2",pr_default);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_savepagev2",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8SDT_Error = new SdtSDT_Error(context);
         AV23ReceptionistId = Guid.Empty;
         GXt_char1 = "";
         A89ReceptionistId = Guid.Empty;
         P00BG2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BG2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BG2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         P00BG3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BG3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BG3_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         P00BG3_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         P00BG3_A632ToolBoxLastUpdateTime = new DateTime[] {DateTime.MinValue} ;
         P00BG3_n632ToolBoxLastUpdateTime = new bool[] {false} ;
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A632ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
         P00BG6_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         P00BG7_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00BG7_A516PageId = new Guid[] {Guid.Empty} ;
         P00BG7_A517PageName = new string[] {""} ;
         P00BG7_A525PageType = new string[] {""} ;
         P00BG7_A518PageStructure = new string[] {""} ;
         A516PageId = Guid.Empty;
         A517PageName = "";
         A525PageType = "";
         A518PageStructure = "";
         O518PageStructure = "";
         AV19SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV10CleanedPageStructure = "";
         AV22SDT_InfoContent = new SdtSDT_InfoContent(context);
         AV18SDT_ContentPage = new SdtSDT_ContentPage(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagev2__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagev2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_savepagev2__default(),
            new Object[][] {
                new Object[] {
               P00BG2_A11OrganisationId, P00BG2_A29LocationId, P00BG2_A89ReceptionistId
               }
               , new Object[] {
               P00BG3_A29LocationId, P00BG3_A11OrganisationId, P00BG3_A630ToolBoxLastUpdateReceptionistI, P00BG3_n630ToolBoxLastUpdateReceptionistI, P00BG3_A632ToolBoxLastUpdateTime, P00BG3_n632ToolBoxLastUpdateTime
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00BG6_A523AppVersionId
               }
               , new Object[] {
               P00BG7_A523AppVersionId, P00BG7_A516PageId, P00BG7_A517PageName, P00BG7_A525PageType, P00BG7_A518PageStructure
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTBG5 ;
      private string GXt_char1 ;
      private DateTime A632ToolBoxLastUpdateTime ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private bool n632ToolBoxLastUpdateTime ;
      private string AV16PageStructure ;
      private string A518PageStructure ;
      private string O518PageStructure ;
      private string AV10CleanedPageStructure ;
      private string AV15PageName ;
      private string AV17PageType ;
      private string A517PageName ;
      private string A525PageType ;
      private Guid AV9AppVersionId ;
      private Guid AV14PageId ;
      private Guid AV23ReceptionistId ;
      private Guid A89ReceptionistId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV8SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BG2_A11OrganisationId ;
      private Guid[] P00BG2_A29LocationId ;
      private Guid[] P00BG2_A89ReceptionistId ;
      private Guid[] P00BG3_A29LocationId ;
      private Guid[] P00BG3_A11OrganisationId ;
      private Guid[] P00BG3_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] P00BG3_n630ToolBoxLastUpdateReceptionistI ;
      private DateTime[] P00BG3_A632ToolBoxLastUpdateTime ;
      private bool[] P00BG3_n632ToolBoxLastUpdateTime ;
      private Guid[] P00BG6_A523AppVersionId ;
      private Guid[] P00BG7_A523AppVersionId ;
      private Guid[] P00BG7_A516PageId ;
      private string[] P00BG7_A517PageName ;
      private string[] P00BG7_A525PageType ;
      private string[] P00BG7_A518PageStructure ;
      private SdtSDT_MenuPage AV19SDT_MenuPage ;
      private SdtSDT_InfoContent AV22SDT_InfoContent ;
      private SdtSDT_ContentPage AV18SDT_ContentPage ;
      private SdtSDT_Error aP5_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_savepagev2__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class prc_savepagev2__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class prc_savepagev2__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new UpdateCursor(def[2])
      ,new UpdateCursor(def[3])
      ,new ForEachCursor(def[4])
      ,new ForEachCursor(def[5])
      ,new UpdateCursor(def[6])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00BG2;
       prmP00BG2 = new Object[] {
       new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BG3;
       prmP00BG3 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BG4;
       prmP00BG4 = new Object[] {
       new ParDef("ToolBoxLastUpdateReceptionistI",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ToolBoxLastUpdateTime",GXType.DateTime,0,5){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BG5;
       prmP00BG5 = new Object[] {
       new ParDef("ToolBoxLastUpdateReceptionistI",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ToolBoxLastUpdateTime",GXType.DateTime,0,5){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BG6;
       prmP00BG6 = new Object[] {
       new ParDef("AV9AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BG7;
       prmP00BG7 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV14PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BG8;
       prmP00BG8 = new Object[] {
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BG2", "SELECT OrganisationId, LocationId, ReceptionistId FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00BG3", "SELECT LocationId, OrganisationId, ToolBoxLastUpdateReceptionistI, ToolBoxLastUpdateTime FROM Trn_Location WHERE LocationId = :LocationId and OrganisationId = :OrganisationId ORDER BY LocationId, OrganisationId  FOR UPDATE OF Trn_Location",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG3,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BG4", "SAVEPOINT gxupdate;UPDATE Trn_Location SET ToolBoxLastUpdateReceptionistI=:ToolBoxLastUpdateReceptionistI, ToolBoxLastUpdateTime=:ToolBoxLastUpdateTime  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BG4)
          ,new CursorDef("P00BG5", "SAVEPOINT gxupdate;UPDATE Trn_Location SET ToolBoxLastUpdateReceptionistI=:ToolBoxLastUpdateReceptionistI, ToolBoxLastUpdateTime=:ToolBoxLastUpdateTime  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BG5)
          ,new CursorDef("P00BG6", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AV9AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BG7", "SELECT AppVersionId, PageId, PageName, PageType, PageStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV14PageId ORDER BY AppVersionId, PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BG8", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageName=:PageName, PageStructure=:PageStructure  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BG8)
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
    }
 }

}

}
