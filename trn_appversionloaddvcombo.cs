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
   public class trn_appversionloaddvcombo : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_appversion_Services_Execute" ;
         }

      }

      public trn_appversionloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appversionloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_AppVersionId ,
                           Guid aP4_Cond_OrganisationId ,
                           string aP5_SearchTxtParms ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20AppVersionId = aP3_AppVersionId;
         this.AV30Cond_OrganisationId = aP4_Cond_OrganisationId;
         this.AV21SearchTxtParms = aP5_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP6_SelectedValue=this.AV22SelectedValue;
         aP7_SelectedText=this.AV23SelectedText;
         aP8_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_AppVersionId ,
                                Guid aP4_Cond_OrganisationId ,
                                string aP5_SearchTxtParms ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_AppVersionId, aP4_Cond_OrganisationId, aP5_SearchTxtParms, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_AppVersionId ,
                                 Guid aP4_Cond_OrganisationId ,
                                 string aP5_SearchTxtParms ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20AppVersionId = aP3_AppVersionId;
         this.AV30Cond_OrganisationId = aP4_Cond_OrganisationId;
         this.AV21SearchTxtParms = aP5_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         SubmitImpl();
         aP6_SelectedValue=this.AV22SelectedValue;
         aP7_SelectedText=this.AV23SelectedText;
         aP8_Combo_DataJson=this.AV24Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV21SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV21SearchTxtParms : StringUtil.Substring( AV21SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "LocationId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_LOCATIONID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "OrganisationId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ORGANISATIONID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_LOCATIONID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A31LocationName ,
                                                 A11OrganisationId ,
                                                 AV30Cond_OrganisationId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P00DN2 */
            pr_default.execute(0, new Object[] {AV30Cond_OrganisationId, lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P00DN2_A11OrganisationId[0];
               n11OrganisationId = P00DN2_n11OrganisationId[0];
               A31LocationName = P00DN2_A31LocationName[0];
               A29LocationId = P00DN2_A29LocationId[0];
               n29LocationId = P00DN2_n29LocationId[0];
               AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A29LocationId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A31LocationName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DN3 */
                  pr_default.execute(1, new Object[] {AV20AppVersionId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A11OrganisationId = P00DN3_A11OrganisationId[0];
                     n11OrganisationId = P00DN3_n11OrganisationId[0];
                     A523AppVersionId = P00DN3_A523AppVersionId[0];
                     A29LocationId = P00DN3_A29LocationId[0];
                     n29LocationId = P00DN3_n29LocationId[0];
                     A31LocationName = P00DN3_A31LocationName[0];
                     A31LocationName = P00DN3_A31LocationName[0];
                     AV22SelectedValue = ((Guid.Empty==A29LocationId) ? "" : StringUtil.Trim( A29LocationId.ToString()));
                     AV23SelectedText = A31LocationName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV28LocationId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P00DN4 */
                  pr_default.execute(2, new Object[] {AV28LocationId, AV30Cond_OrganisationId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A11OrganisationId = P00DN4_A11OrganisationId[0];
                     n11OrganisationId = P00DN4_n11OrganisationId[0];
                     A29LocationId = P00DN4_A29LocationId[0];
                     n29LocationId = P00DN4_n29LocationId[0];
                     A31LocationName = P00DN4_A31LocationName[0];
                     AV23SelectedText = A31LocationName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_ORGANISATIONID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom5 = AV12SkipItems;
            GXPagingTo5 = AV11MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A13OrganisationName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P00DN5 */
            pr_default.execute(3, new Object[] {lV14SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A13OrganisationName = P00DN5_A13OrganisationName[0];
               A11OrganisationId = P00DN5_A11OrganisationId[0];
               n11OrganisationId = P00DN5_n11OrganisationId[0];
               AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A11OrganisationId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A13OrganisationName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DN6 */
                  pr_default.execute(4, new Object[] {AV20AppVersionId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A523AppVersionId = P00DN6_A523AppVersionId[0];
                     A11OrganisationId = P00DN6_A11OrganisationId[0];
                     n11OrganisationId = P00DN6_n11OrganisationId[0];
                     A13OrganisationName = P00DN6_A13OrganisationName[0];
                     A13OrganisationName = P00DN6_A13OrganisationName[0];
                     AV22SelectedValue = ((Guid.Empty==A11OrganisationId) ? "" : StringUtil.Trim( A11OrganisationId.ToString()));
                     AV23SelectedText = A13OrganisationName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV29OrganisationId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P00DN7 */
                  pr_default.execute(5, new Object[] {AV29OrganisationId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A11OrganisationId = P00DN7_A11OrganisationId[0];
                     n11OrganisationId = P00DN7_n11OrganisationId[0];
                     A13OrganisationName = P00DN7_A13OrganisationName[0];
                     AV23SelectedText = A13OrganisationName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(5);
               }
            }
         }
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
         AV22SelectedValue = "";
         AV23SelectedText = "";
         AV24Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         lV14SearchTxt = "";
         A31LocationName = "";
         A11OrganisationId = Guid.Empty;
         P00DN2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DN2_n11OrganisationId = new bool[] {false} ;
         P00DN2_A31LocationName = new string[] {""} ;
         P00DN2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DN2_n29LocationId = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00DN3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DN3_n11OrganisationId = new bool[] {false} ;
         P00DN3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DN3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DN3_n29LocationId = new bool[] {false} ;
         P00DN3_A31LocationName = new string[] {""} ;
         A523AppVersionId = Guid.Empty;
         AV28LocationId = Guid.Empty;
         P00DN4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DN4_n11OrganisationId = new bool[] {false} ;
         P00DN4_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DN4_n29LocationId = new bool[] {false} ;
         P00DN4_A31LocationName = new string[] {""} ;
         A13OrganisationName = "";
         P00DN5_A13OrganisationName = new string[] {""} ;
         P00DN5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DN5_n11OrganisationId = new bool[] {false} ;
         P00DN6_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DN6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DN6_n11OrganisationId = new bool[] {false} ;
         P00DN6_A13OrganisationName = new string[] {""} ;
         AV29OrganisationId = Guid.Empty;
         P00DN7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DN7_n11OrganisationId = new bool[] {false} ;
         P00DN7_A13OrganisationName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appversionloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00DN2_A11OrganisationId, P00DN2_A31LocationName, P00DN2_A29LocationId
               }
               , new Object[] {
               P00DN3_A11OrganisationId, P00DN3_n11OrganisationId, P00DN3_A523AppVersionId, P00DN3_A29LocationId, P00DN3_n29LocationId, P00DN3_A31LocationName
               }
               , new Object[] {
               P00DN4_A11OrganisationId, P00DN4_A29LocationId, P00DN4_A31LocationName
               }
               , new Object[] {
               P00DN5_A13OrganisationName, P00DN5_A11OrganisationId
               }
               , new Object[] {
               P00DN6_A523AppVersionId, P00DN6_A11OrganisationId, P00DN6_n11OrganisationId, P00DN6_A13OrganisationName
               }
               , new Object[] {
               P00DN7_A11OrganisationId, P00DN7_A13OrganisationName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A31LocationName ;
      private string A13OrganisationName ;
      private Guid AV20AppVersionId ;
      private Guid AV30Cond_OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A523AppVersionId ;
      private Guid AV28LocationId ;
      private Guid AV29OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DN2_A11OrganisationId ;
      private bool[] P00DN2_n11OrganisationId ;
      private string[] P00DN2_A31LocationName ;
      private Guid[] P00DN2_A29LocationId ;
      private bool[] P00DN2_n29LocationId ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private Guid[] P00DN3_A11OrganisationId ;
      private bool[] P00DN3_n11OrganisationId ;
      private Guid[] P00DN3_A523AppVersionId ;
      private Guid[] P00DN3_A29LocationId ;
      private bool[] P00DN3_n29LocationId ;
      private string[] P00DN3_A31LocationName ;
      private Guid[] P00DN4_A11OrganisationId ;
      private bool[] P00DN4_n11OrganisationId ;
      private Guid[] P00DN4_A29LocationId ;
      private bool[] P00DN4_n29LocationId ;
      private string[] P00DN4_A31LocationName ;
      private string[] P00DN5_A13OrganisationName ;
      private Guid[] P00DN5_A11OrganisationId ;
      private bool[] P00DN5_n11OrganisationId ;
      private Guid[] P00DN6_A523AppVersionId ;
      private Guid[] P00DN6_A11OrganisationId ;
      private bool[] P00DN6_n11OrganisationId ;
      private string[] P00DN6_A13OrganisationName ;
      private Guid[] P00DN7_A11OrganisationId ;
      private bool[] P00DN7_n11OrganisationId ;
      private string[] P00DN7_A13OrganisationName ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
   }

   public class trn_appversionloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DN2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A31LocationName ,
                                             Guid A11OrganisationId ,
                                             Guid AV30Cond_OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " OrganisationId, LocationName, LocationId";
         sFromString = " FROM Trn_Location";
         sOrderString = "";
         AddWhere(sWhereString, "(OrganisationId = :AV30Cond_OrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(LocationName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         sOrderString += " ORDER BY LocationName, LocationId, OrganisationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00DN5( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A13OrganisationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " OrganisationName, OrganisationId";
         sFromString = " FROM Trn_Organisation";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(OrganisationName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY OrganisationName, OrganisationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DN2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
               case 3 :
                     return conditional_P00DN5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DN3;
          prmP00DN3 = new Object[] {
          new ParDef("AV20AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DN4;
          prmP00DN4 = new Object[] {
          new ParDef("AV28LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV30Cond_OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DN6;
          prmP00DN6 = new Object[] {
          new ParDef("AV20AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DN7;
          prmP00DN7 = new Object[] {
          new ParDef("AV29OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DN2;
          prmP00DN2 = new Object[] {
          new ParDef("AV30Cond_OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00DN5;
          prmP00DN5 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DN2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DN2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DN3", "SELECT T1.OrganisationId, T1.AppVersionId, T1.LocationId, T2.LocationName FROM (Trn_AppVersion T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) WHERE T1.AppVersionId = :AV20AppVersionId ORDER BY T1.AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DN3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DN4", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location WHERE LocationId = :AV28LocationId and OrganisationId = :AV30Cond_OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DN4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DN5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DN5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DN6", "SELECT T1.AppVersionId, T1.OrganisationId, T2.OrganisationName FROM (Trn_AppVersion T1 LEFT JOIN Trn_Organisation T2 ON T2.OrganisationId = T1.OrganisationId) WHERE T1.AppVersionId = :AV20AppVersionId ORDER BY T1.AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DN6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DN7", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation WHERE OrganisationId = :AV29OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DN7,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
