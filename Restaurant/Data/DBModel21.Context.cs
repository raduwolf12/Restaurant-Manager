﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class databaseWPFEntities1 : DbContext
    {
        public databaseWPFEntities1()
            : base("name=databaseWPFEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alergeni> Alergenis { get; set; }
        public virtual DbSet<Categorii> Categoriis { get; set; }
        public virtual DbSet<Comanda_Meniu> Comanda_Meniu { get; set; }
        public virtual DbSet<Comanda_Preparat> Comanda_Preparat { get; set; }
        public virtual DbSet<Comenzi> Comenzis { get; set; }
        public virtual DbSet<Meniu> Menius { get; set; }
        public virtual DbSet<Poze> Pozes { get; set; }
        public virtual DbSet<Preparate> Preparates { get; set; }
        public virtual DbSet<Pret_Comenzi> Pret_Comenzi { get; set; }
        public virtual DbSet<Roluri> Roluris { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int CreateAlergeniPreparat(string denumirePrep, string denumireAlerg)
        {
            var denumirePrepParameter = denumirePrep != null ?
                new ObjectParameter("DenumirePrep", denumirePrep) :
                new ObjectParameter("DenumirePrep", typeof(string));
    
            var denumireAlergParameter = denumireAlerg != null ?
                new ObjectParameter("DenumireAlerg", denumireAlerg) :
                new ObjectParameter("DenumireAlerg", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateAlergeniPreparat", denumirePrepParameter, denumireAlergParameter);
        }
    
        public virtual int CreateMenu(string denumire, string categorie)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateMenu", denumireParameter, categorieParameter);
        }
    
        public virtual int CreateMenuPreparat(string meniu, string preparat, Nullable<int> cantitate)
        {
            var meniuParameter = meniu != null ?
                new ObjectParameter("Meniu", meniu) :
                new ObjectParameter("Meniu", typeof(string));
    
            var preparatParameter = preparat != null ?
                new ObjectParameter("Preparat", preparat) :
                new ObjectParameter("Preparat", typeof(string));
    
            var cantitateParameter = cantitate.HasValue ?
                new ObjectParameter("Cantitate", cantitate) :
                new ObjectParameter("Cantitate", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateMenuPreparat", meniuParameter, preparatParameter, cantitateParameter);
        }
    
        public virtual int CreatePoza(string link)
        {
            var linkParameter = link != null ?
                new ObjectParameter("Link", link) :
                new ObjectParameter("Link", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreatePoza", linkParameter);
        }
    
        public virtual int CreatePozePreparat(string denumirePrep, string link)
        {
            var denumirePrepParameter = denumirePrep != null ?
                new ObjectParameter("DenumirePrep", denumirePrep) :
                new ObjectParameter("DenumirePrep", typeof(string));
    
            var linkParameter = link != null ?
                new ObjectParameter("Link", link) :
                new ObjectParameter("Link", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreatePozePreparat", denumirePrepParameter, linkParameter);
        }
    
        public virtual int CreatePreparat(string denumire, Nullable<double> pret, Nullable<int> cantitatePortie, Nullable<int> cantitateRestaurant, string categorie)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            var pretParameter = pret.HasValue ?
                new ObjectParameter("Pret", pret) :
                new ObjectParameter("Pret", typeof(double));
    
            var cantitatePortieParameter = cantitatePortie.HasValue ?
                new ObjectParameter("CantitatePortie", cantitatePortie) :
                new ObjectParameter("CantitatePortie", typeof(int));
    
            var cantitateRestaurantParameter = cantitateRestaurant.HasValue ?
                new ObjectParameter("CantitateRestaurant", cantitateRestaurant) :
                new ObjectParameter("CantitateRestaurant", typeof(int));
    
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreatePreparat", denumireParameter, pretParameter, cantitatePortieParameter, cantitateRestaurantParameter, categorieParameter);
        }
    
        public virtual int CreateUser(string name, string surname, string email, string adress, string phone, string password)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var surnameParameter = surname != null ?
                new ObjectParameter("Surname", surname) :
                new ObjectParameter("Surname", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var adressParameter = adress != null ?
                new ObjectParameter("Adress", adress) :
                new ObjectParameter("Adress", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateUser", nameParameter, surnameParameter, emailParameter, adressParameter, phoneParameter, passwordParameter);
        }
    
        public virtual int CreateUser2(string name, string surname, string email, string adress, string phone, string password)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var surnameParameter = surname != null ?
                new ObjectParameter("Surname", surname) :
                new ObjectParameter("Surname", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var adressParameter = adress != null ?
                new ObjectParameter("Adress", adress) :
                new ObjectParameter("Adress", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateUser2", nameParameter, surnameParameter, emailParameter, adressParameter, phoneParameter, passwordParameter);
        }
    
        public virtual int DeleteAlergeniPreparat(string denumire)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteAlergeniPreparat", denumireParameter);
        }
    
        public virtual int DeleteMeniu(string denumire)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteMeniu", denumireParameter);
        }
    
        public virtual int DeleteMeniuPreparate(string denumire)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteMeniuPreparate", denumireParameter);
        }
    
        public virtual int DeletePozePreparat(string denumire)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePozePreparat", denumireParameter);
        }
    
        public virtual int DeletePreparat(string denumirePrep)
        {
            var denumirePrepParameter = denumirePrep != null ?
                new ObjectParameter("DenumirePrep", denumirePrep) :
                new ObjectParameter("DenumirePrep", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePreparat", denumirePrepParameter);
        }
    
        public virtual ObjectResult<GetAllAlergeni_Result> GetAllAlergeni()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllAlergeni_Result>("GetAllAlergeni");
        }
    
        public virtual ObjectResult<GetAllCategorii_Result> GetAllCategorii()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllCategorii_Result>("GetAllCategorii");
        }
    
        public virtual ObjectResult<GetAllStatus_Result> GetAllStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllStatus_Result>("GetAllStatus");
        }
    
        public virtual ObjectResult<Nullable<int>> GetComandaInregistrataId(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetComandaInregistrataId", userIdParameter);
        }
    
        public virtual ObjectResult<GetComenziByEmail_Result> GetComenziByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetComenziByEmail_Result>("GetComenziByEmail", emailParameter);
        }
    
        public virtual ObjectResult<GetComenziFull_Result> GetComenziFull()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetComenziFull_Result>("GetComenziFull");
        }
    
        public virtual int InregistrareComanda(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InregistrareComanda", userIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> LoginCheck(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("LoginCheck", emailParameter, passwordParameter);
        }
    
        public virtual ObjectResult<LoginCheck1_Result> LoginCheck1(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoginCheck1_Result>("LoginCheck1", emailParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> LoginCheckTest(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("LoginCheckTest", emailParameter, passwordParameter);
        }
    
        public virtual int PretComanda(Nullable<int> userId, Nullable<double> pret)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var pretParameter = pret.HasValue ?
                new ObjectParameter("Pret", pret) :
                new ObjectParameter("Pret", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PretComanda", userIdParameter, pretParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<string> SPGetAllergeniForPreparat(string denumire)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SPGetAllergeniForPreparat", denumireParameter);
        }
    
        public virtual ObjectResult<SPGetAllMenues_Result> SPGetAllMenues()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGetAllMenues_Result>("SPGetAllMenues");
        }
    
        public virtual ObjectResult<SPGetAllPhotosForPreparat_Result> SPGetAllPhotosForPreparat(string denumire)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGetAllPhotosForPreparat_Result>("SPGetAllPhotosForPreparat", denumireParameter);
        }
    
        public virtual ObjectResult<SPGetMeniuriByCategorie_Result> SPGetMeniuriByCategorie(string categorie)
        {
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGetMeniuriByCategorie_Result>("SPGetMeniuriByCategorie", categorieParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SPGetMenuIdByDenumire(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SPGetMenuIdByDenumire", nameParameter);
        }
    
        public virtual ObjectResult<SPGetPreparate_Result> SPGetPreparate()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGetPreparate_Result>("SPGetPreparate");
        }
    
        public virtual ObjectResult<SPGetPreparateByCategorie_Result> SPGetPreparateByCategorie(string categorie)
        {
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGetPreparateByCategorie_Result>("SPGetPreparateByCategorie", categorieParameter);
        }
    
        public virtual ObjectResult<SPGetPreparateByMenu_Result> SPGetPreparateByMenu(string denumire)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGetPreparateByMenu_Result>("SPGetPreparateByMenu", denumireParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> SPGetPreparatePriceSumByMenu(string denumire)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("SPGetPreparatePriceSumByMenu", denumireParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SPGetPreparatIdByDenumire(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SPGetPreparatIdByDenumire", nameParameter);
        }
    
        public virtual int SPInsertMenuInComanda(Nullable<int> id_comanda, Nullable<int> id_meniu, Nullable<int> cantitate, Nullable<double> pret_CM)
        {
            var id_comandaParameter = id_comanda.HasValue ?
                new ObjectParameter("id_comanda", id_comanda) :
                new ObjectParameter("id_comanda", typeof(int));
    
            var id_meniuParameter = id_meniu.HasValue ?
                new ObjectParameter("id_meniu", id_meniu) :
                new ObjectParameter("id_meniu", typeof(int));
    
            var cantitateParameter = cantitate.HasValue ?
                new ObjectParameter("cantitate", cantitate) :
                new ObjectParameter("cantitate", typeof(int));
    
            var pret_CMParameter = pret_CM.HasValue ?
                new ObjectParameter("pret_CM", pret_CM) :
                new ObjectParameter("pret_CM", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPInsertMenuInComanda", id_comandaParameter, id_meniuParameter, cantitateParameter, pret_CMParameter);
        }
    
        public virtual int SPInsertMenuInComanda2(Nullable<int> userId, string name, Nullable<int> cantitate, Nullable<double> pret_CM)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var cantitateParameter = cantitate.HasValue ?
                new ObjectParameter("cantitate", cantitate) :
                new ObjectParameter("cantitate", typeof(int));
    
            var pret_CMParameter = pret_CM.HasValue ?
                new ObjectParameter("pret_CM", pret_CM) :
                new ObjectParameter("pret_CM", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPInsertMenuInComanda2", userIdParameter, nameParameter, cantitateParameter, pret_CMParameter);
        }
    
        public virtual int SPInsertPreparatInComanda(Nullable<int> id_comanda, Nullable<int> id_meniu, Nullable<int> cantitate, Nullable<double> pret_CP)
        {
            var id_comandaParameter = id_comanda.HasValue ?
                new ObjectParameter("id_comanda", id_comanda) :
                new ObjectParameter("id_comanda", typeof(int));
    
            var id_meniuParameter = id_meniu.HasValue ?
                new ObjectParameter("id_meniu", id_meniu) :
                new ObjectParameter("id_meniu", typeof(int));
    
            var cantitateParameter = cantitate.HasValue ?
                new ObjectParameter("cantitate", cantitate) :
                new ObjectParameter("cantitate", typeof(int));
    
            var pret_CPParameter = pret_CP.HasValue ?
                new ObjectParameter("pret_CP", pret_CP) :
                new ObjectParameter("pret_CP", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPInsertPreparatInComanda", id_comandaParameter, id_meniuParameter, cantitateParameter, pret_CPParameter);
        }
    
        public virtual int SPInsertPreparatInComanda2(Nullable<int> userId, string name, Nullable<int> cantitate, Nullable<double> pret_CP)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var cantitateParameter = cantitate.HasValue ?
                new ObjectParameter("cantitate", cantitate) :
                new ObjectParameter("cantitate", typeof(int));
    
            var pret_CPParameter = pret_CP.HasValue ?
                new ObjectParameter("pret_CP", pret_CP) :
                new ObjectParameter("pret_CP", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPInsertPreparatInComanda2", userIdParameter, nameParameter, cantitateParameter, pret_CPParameter);
        }
    
        public virtual ObjectResult<SPLoginAndReturnUser_Result> SPLoginAndReturnUser(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPLoginAndReturnUser_Result>("SPLoginAndReturnUser", emailParameter, passwordParameter);
        }
    
        public virtual int spLoginCheck(string email, string password, ObjectParameter loginStatus, ObjectParameter error)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spLoginCheck", emailParameter, passwordParameter, loginStatus, error);
        }
    
        public virtual ObjectResult<SPSearchMenuAll_Result> SPSearchMenuAll(string denumire)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPSearchMenuAll_Result>("SPSearchMenuAll", denumireParameter);
        }
    
        public virtual ObjectResult<SPSearchMenuByCategorie_Result> SPSearchMenuByCategorie(string denumire, string categorie)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPSearchMenuByCategorie_Result>("SPSearchMenuByCategorie", denumireParameter, categorieParameter);
        }
    
        public virtual ObjectResult<SPSearchMenuByCategorie2_Result> SPSearchMenuByCategorie2(string denumire, string categorie)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPSearchMenuByCategorie2_Result>("SPSearchMenuByCategorie2", denumireParameter, categorieParameter);
        }
    
        public virtual ObjectResult<SPSearchPreparatAll_Result> SPSearchPreparatAll(string denumire)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPSearchPreparatAll_Result>("SPSearchPreparatAll", denumireParameter);
        }
    
        public virtual ObjectResult<SPSearchPreparatByCategorie_Result> SPSearchPreparatByCategorie(string denumire, string categorie)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPSearchPreparatByCategorie_Result>("SPSearchPreparatByCategorie", denumireParameter, categorieParameter);
        }
    
        public virtual ObjectResult<SPSelectProductByCategorie_Result> SPSelectProductByCategorie(string product)
        {
            var productParameter = product != null ?
                new ObjectParameter("Product", product) :
                new ObjectParameter("Product", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPSelectProductByCategorie_Result>("SPSelectProductByCategorie", productParameter);
        }
    
        public virtual int UpdateComandaStatus(Nullable<int> userId, string denumireStatus, Nullable<int> iDComanda)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var denumireStatusParameter = denumireStatus != null ?
                new ObjectParameter("DenumireStatus", denumireStatus) :
                new ObjectParameter("DenumireStatus", typeof(string));
    
            var iDComandaParameter = iDComanda.HasValue ?
                new ObjectParameter("IDComanda", iDComanda) :
                new ObjectParameter("IDComanda", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateComandaStatus", userIdParameter, denumireStatusParameter, iDComandaParameter);
        }
    
        public virtual int UpdateMeniu(string denumire, string categorie, Nullable<int> id)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateMeniu", denumireParameter, categorieParameter, idParameter);
        }
    
        public virtual int UpdatePreparat(string denumire, Nullable<double> pret, Nullable<int> cantitatePortie, Nullable<int> cantitateRestaurant, string categorie, Nullable<int> iD)
        {
            var denumireParameter = denumire != null ?
                new ObjectParameter("Denumire", denumire) :
                new ObjectParameter("Denumire", typeof(string));
    
            var pretParameter = pret.HasValue ?
                new ObjectParameter("Pret", pret) :
                new ObjectParameter("Pret", typeof(double));
    
            var cantitatePortieParameter = cantitatePortie.HasValue ?
                new ObjectParameter("CantitatePortie", cantitatePortie) :
                new ObjectParameter("CantitatePortie", typeof(int));
    
            var cantitateRestaurantParameter = cantitateRestaurant.HasValue ?
                new ObjectParameter("CantitateRestaurant", cantitateRestaurant) :
                new ObjectParameter("CantitateRestaurant", typeof(int));
    
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePreparat", denumireParameter, pretParameter, cantitatePortieParameter, cantitateRestaurantParameter, categorieParameter, iDParameter);
        }
    }
}