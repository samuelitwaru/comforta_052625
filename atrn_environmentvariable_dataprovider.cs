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
   public class atrn_environmentvariable_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new atrn_environmentvariable_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtTrn_EnvironmentVariable> aP0_Gxm2rootcol = new GXBCCollection<SdtTrn_EnvironmentVariable>()  ;
         execute(out aP0_Gxm2rootcol);
         return GX.GXRuntime.ExitCode ;
      }

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

      public atrn_environmentvariable_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atrn_environmentvariable_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtTrn_EnvironmentVariable> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_EnvironmentVariable>( context, "Trn_EnvironmentVariable", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtTrn_EnvironmentVariable> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtTrn_EnvironmentVariable> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_EnvironmentVariable>( context, "Trn_EnvironmentVariable", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1trn_environmentvariable = new SdtTrn_EnvironmentVariable(context);
         Gxm2rootcol.Add(Gxm1trn_environmentvariable, 0);
         Gxm1trn_environmentvariable.gxTpr_Environmentvariablekey = "AmazonAccessKey";
         Gxm1trn_environmentvariable.gxTpr_Environmentvariablevalue = "AKIAUBBFPYBYYILNY7V6";
         Gxm1trn_environmentvariable = new SdtTrn_EnvironmentVariable(context);
         Gxm2rootcol.Add(Gxm1trn_environmentvariable, 0);
         Gxm1trn_environmentvariable.gxTpr_Environmentvariablekey = "AmazonSecretKey";
         Gxm1trn_environmentvariable.gxTpr_Environmentvariablevalue = "6poWMzGTcRg03vzpdz2m75U3W6mK9hq7Fv9GzGk7";
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
         Gxm1trn_environmentvariable = new SdtTrn_EnvironmentVariable(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtTrn_EnvironmentVariable> Gxm2rootcol ;
      private SdtTrn_EnvironmentVariable Gxm1trn_environmentvariable ;
      private GXBCCollection<SdtTrn_EnvironmentVariable> aP0_Gxm2rootcol ;
   }

}
