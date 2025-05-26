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
   public class prc_countsuppliers : GXProcedure
   {
      public prc_countsuppliers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_countsuppliers( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_SupplierCount )
      {
         this.AV12SupplierCount = 0 ;
         initialize();
         ExecuteImpl();
         aP0_SupplierCount=this.AV12SupplierCount;
      }

      public short executeUdp( )
      {
         execute(out aP0_SupplierCount);
         return AV12SupplierCount ;
      }

      public void executeSubmit( out short aP0_SupplierCount )
      {
         this.AV12SupplierCount = 0 ;
         SubmitImpl();
         aP0_SupplierCount=this.AV12SupplierCount;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12SupplierCount = 0;
         AV14Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         /* Using cursor P00ES3 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A602SG_LocationSupplierOrganisatio = P00ES3_A602SG_LocationSupplierOrganisatio[0];
            n602SG_LocationSupplierOrganisatio = P00ES3_n602SG_LocationSupplierOrganisatio[0];
            A603SG_LocationSupplierLocationId = P00ES3_A603SG_LocationSupplierLocationId[0];
            n603SG_LocationSupplierLocationId = P00ES3_n603SG_LocationSupplierLocationId[0];
            A584ActiveAppVersionId = P00ES3_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00ES3_n584ActiveAppVersionId[0];
            A598PublishedActiveAppVersionId = P00ES3_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00ES3_n598PublishedActiveAppVersionId[0];
            A42SupplierGenId = P00ES3_A42SupplierGenId[0];
            n42SupplierGenId = P00ES3_n42SupplierGenId[0];
            A601SG_OrganisationSupplierId = P00ES3_A601SG_OrganisationSupplierId[0];
            n601SG_OrganisationSupplierId = P00ES3_n601SG_OrganisationSupplierId[0];
            A40000GXC1 = P00ES3_A40000GXC1[0];
            n40000GXC1 = P00ES3_n40000GXC1[0];
            A584ActiveAppVersionId = P00ES3_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = P00ES3_n584ActiveAppVersionId[0];
            A598PublishedActiveAppVersionId = P00ES3_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = P00ES3_n598PublishedActiveAppVersionId[0];
            A40000GXC1 = P00ES3_A40000GXC1[0];
            n40000GXC1 = P00ES3_n40000GXC1[0];
            /* Using cursor P00ES4 */
            pr_default.execute(1, new Object[] {n602SG_LocationSupplierOrganisatio, A602SG_LocationSupplierOrganisatio});
            pr_default.close(1);
            /* Using cursor P00ES5 */
            pr_default.execute(2, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
            pr_default.close(2);
            /* Using cursor P00ES6 */
            pr_default.execute(3, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
            pr_default.close(3);
            AV12SupplierCount = (short)(A40000GXC1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.close(1);
         pr_default.close(3);
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

      protected override void CloseCursors( )
      {
         pr_default.close(2);
      }

      public override void initialize( )
      {
         AV14Udparg1 = Guid.Empty;
         P00ES3_A602SG_LocationSupplierOrganisatio = new Guid[] {Guid.Empty} ;
         P00ES3_n602SG_LocationSupplierOrganisatio = new bool[] {false} ;
         P00ES3_A603SG_LocationSupplierLocationId = new Guid[] {Guid.Empty} ;
         P00ES3_n603SG_LocationSupplierLocationId = new bool[] {false} ;
         P00ES3_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00ES3_n584ActiveAppVersionId = new bool[] {false} ;
         P00ES3_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         P00ES3_n598PublishedActiveAppVersionId = new bool[] {false} ;
         P00ES3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00ES3_n42SupplierGenId = new bool[] {false} ;
         P00ES3_A601SG_OrganisationSupplierId = new Guid[] {Guid.Empty} ;
         P00ES3_n601SG_OrganisationSupplierId = new bool[] {false} ;
         P00ES3_A40000GXC1 = new int[1] ;
         P00ES3_n40000GXC1 = new bool[] {false} ;
         A602SG_LocationSupplierOrganisatio = Guid.Empty;
         A603SG_LocationSupplierLocationId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         A601SG_OrganisationSupplierId = Guid.Empty;
         P00ES4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00ES4_n11OrganisationId = new bool[] {false} ;
         P00ES5_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00ES6_A523AppVersionId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_countsuppliers__default(),
            new Object[][] {
                new Object[] {
               P00ES3_A602SG_LocationSupplierOrganisatio, P00ES3_n602SG_LocationSupplierOrganisatio, P00ES3_A603SG_LocationSupplierLocationId, P00ES3_n603SG_LocationSupplierLocationId, P00ES3_A584ActiveAppVersionId, P00ES3_n584ActiveAppVersionId, P00ES3_A598PublishedActiveAppVersionId, P00ES3_n598PublishedActiveAppVersionId, P00ES3_A42SupplierGenId, P00ES3_A601SG_OrganisationSupplierId,
               P00ES3_n601SG_OrganisationSupplierId, P00ES3_A40000GXC1, P00ES3_n40000GXC1
               }
               , new Object[] {
               P00ES4_A11OrganisationId
               }
               , new Object[] {
               P00ES5_A523AppVersionId
               }
               , new Object[] {
               P00ES6_A523AppVersionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12SupplierCount ;
      private int A40000GXC1 ;
      private bool n602SG_LocationSupplierOrganisatio ;
      private bool n603SG_LocationSupplierLocationId ;
      private bool n584ActiveAppVersionId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n42SupplierGenId ;
      private bool n601SG_OrganisationSupplierId ;
      private bool n40000GXC1 ;
      private Guid AV14Udparg1 ;
      private Guid A602SG_LocationSupplierOrganisatio ;
      private Guid A603SG_LocationSupplierLocationId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A42SupplierGenId ;
      private Guid A601SG_OrganisationSupplierId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00ES3_A602SG_LocationSupplierOrganisatio ;
      private bool[] P00ES3_n602SG_LocationSupplierOrganisatio ;
      private Guid[] P00ES3_A603SG_LocationSupplierLocationId ;
      private bool[] P00ES3_n603SG_LocationSupplierLocationId ;
      private Guid[] P00ES3_A584ActiveAppVersionId ;
      private bool[] P00ES3_n584ActiveAppVersionId ;
      private Guid[] P00ES3_A598PublishedActiveAppVersionId ;
      private bool[] P00ES3_n598PublishedActiveAppVersionId ;
      private Guid[] P00ES3_A42SupplierGenId ;
      private bool[] P00ES3_n42SupplierGenId ;
      private Guid[] P00ES3_A601SG_OrganisationSupplierId ;
      private bool[] P00ES3_n601SG_OrganisationSupplierId ;
      private int[] P00ES3_A40000GXC1 ;
      private bool[] P00ES3_n40000GXC1 ;
      private Guid[] P00ES4_A11OrganisationId ;
      private bool[] P00ES4_n11OrganisationId ;
      private Guid[] P00ES5_A523AppVersionId ;
      private Guid[] P00ES6_A523AppVersionId ;
      private short aP0_SupplierCount ;
   }

   public class prc_countsuppliers__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00ES3;
          prmP00ES3 = new Object[] {
          };
          Object[] prmP00ES4;
          prmP00ES4 = new Object[] {
          new ParDef("SG_LocationSupplierOrganisatio",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmP00ES5;
          prmP00ES5 = new Object[] {
          new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmP00ES6;
          prmP00ES6 = new Object[] {
          new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00ES3", "SELECT T1.SG_LocationSupplierOrganisatio AS SG_LocationSupplierOrganisatio, T1.SG_LocationSupplierLocationId AS SG_LocationSupplierLocationId, T2.ActiveAppVersionId, T2.PublishedActiveAppVersionId, T1.SupplierGenId, T1.SG_OrganisationSupplierId, COALESCE( T3.GXC1, 0) AS GXC1 FROM ((Trn_SupplierGen T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.SG_LocationSupplierLocationId AND T2.OrganisationId = T1.SG_LocationSupplierOrganisatio) LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, SupplierGenId, LocationId, OrganisationId FROM Trn_ProductService WHERE T1.SupplierGenId = SupplierGenId and T1.SG_LocationSupplierLocationId = LocationId and T1.SG_OrganisationSupplierId = OrganisationId GROUP BY SupplierGenId, LocationId, OrganisationId ) T3 ON T3.SupplierGenId = T1.SupplierGenId AND T3.LocationId = T1.SG_LocationSupplierLocationId AND T3.OrganisationId = T1.SG_OrganisationSupplierId) ORDER BY T1.SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ES3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00ES4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :SG_LocationSupplierOrganisatio ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ES4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00ES5", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ES5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00ES6", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ES6,1, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((Guid[]) buf[6])[0] = rslt.getGuid(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((Guid[]) buf[8])[0] = rslt.getGuid(5);
                ((Guid[]) buf[9])[0] = rslt.getGuid(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
