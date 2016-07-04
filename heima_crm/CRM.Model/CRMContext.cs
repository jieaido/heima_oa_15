namespace CRM.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CRMContext : DbContext
    {
        public CRMContext()
            : base("name=Model")
        {
        }

        public virtual DbSet<sysFunction> sysFunction { get; set; }
        public virtual DbSet<sysKeyValue> sysKeyValue { get; set; }
        public virtual DbSet<sysMenus> sysMenus { get; set; }
        public virtual DbSet<sysOrganStruct> sysOrganStruct { get; set; }
        public virtual DbSet<sysPermissList> sysPermissList { get; set; }
        public virtual DbSet<sysRole> sysRole { get; set; }
        public virtual DbSet<sysUserInfo> sysUserInfo { get; set; }
        public virtual DbSet<sysUserInfo_Role> sysUserInfo_Role { get; set; }
        public virtual DbSet<wfProcess> wfProcess { get; set; }
        public virtual DbSet<wfRequestForm> wfRequestForm { get; set; }
        public virtual DbSet<wfWork> wfWork { get; set; }
        public virtual DbSet<wfWorkBranch> wfWorkBranch { get; set; }
        public virtual DbSet<wfWorkNodes> wfWorkNodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sysFunction>()
                .HasMany(e => e.sysPermissList)
                .WithRequired(e => e.sysFunction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysKeyValue>()
                .HasMany(e => e.sysOrganStruct)
                .WithRequired(e => e.sysKeyValue)
                .HasForeignKey(e => e.osCateID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysKeyValue>()
                .HasMany(e => e.sysRole)
                .WithRequired(e => e.sysKeyValue)
                .HasForeignKey(e => e.RoleType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysKeyValue>()
                .HasMany(e => e.wfProcess)
                .WithRequired(e => e.sysKeyValue)
                .HasForeignKey(e => e.wfRFStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysKeyValue>()
                .HasMany(e => e.wfRequestForm)
                .WithRequired(e => e.sysKeyValue)
                .HasForeignKey(e => e.wfRFPriority)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysKeyValue>()
                .HasMany(e => e.wfRequestForm1)
                .WithRequired(e => e.sysKeyValue1)
                .HasForeignKey(e => e.wfRFStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysKeyValue>()
                .HasMany(e => e.wfWorkNodes)
                .WithRequired(e => e.sysKeyValue)
                .HasForeignKey(e => e.wfNodeType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysKeyValue>()
                .HasMany(e => e.wfWorkNodes1)
                .WithRequired(e => e.sysKeyValue1)
                .HasForeignKey(e => e.wfnRoleType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysMenus>()
                .Property(e => e.mPicname)
                .IsUnicode(false);

            modelBuilder.Entity<sysMenus>()
                .HasMany(e => e.sysFunction)
                .WithRequired(e => e.sysMenus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysMenus>()
                .HasMany(e => e.sysPermissList)
                .WithRequired(e => e.sysMenus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysOrganStruct>()
                .HasMany(e => e.sysRole)
                .WithOptional(e => e.sysOrganStruct)
                .HasForeignKey(e => e.eDepID);

            modelBuilder.Entity<sysOrganStruct>()
                .HasMany(e => e.sysUserInfo)
                .WithRequired(e => e.sysOrganStruct)
                .HasForeignKey(e => e.uCompanyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysOrganStruct>()
                .HasMany(e => e.sysUserInfo1)
                .WithOptional(e => e.sysOrganStruct1)
                .HasForeignKey(e => e.uDepID);

            modelBuilder.Entity<sysOrganStruct>()
                .HasMany(e => e.sysUserInfo2)
                .WithOptional(e => e.sysOrganStruct2)
                .HasForeignKey(e => e.uWorkGroupID);

            modelBuilder.Entity<sysRole>()
                .HasMany(e => e.sysPermissList)
                .WithRequired(e => e.sysRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysRole>()
                .HasMany(e => e.sysUserInfo_Role)
                .WithRequired(e => e.sysRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysUserInfo>()
                .HasMany(e => e.sysUserInfo_Role)
                .WithRequired(e => e.sysUserInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysUserInfo>()
                .HasMany(e => e.wfRequestForm)
                .WithRequired(e => e.sysUserInfo)
                .HasForeignKey(e => e.fCreatorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<wfRequestForm>()
                .Property(e => e.wfRFLogicSymbol)
                .IsUnicode(false);

            modelBuilder.Entity<wfRequestForm>()
                .Property(e => e.wfRFNum)
                .HasPrecision(18, 0);

            modelBuilder.Entity<wfRequestForm>()
                .HasMany(e => e.wfProcess)
                .WithRequired(e => e.wfRequestForm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<wfWork>()
                .HasMany(e => e.wfRequestForm)
                .WithRequired(e => e.wfWork)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<wfWork>()
                .HasMany(e => e.wfWorkNodes)
                .WithRequired(e => e.wfWork)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<wfWorkNodes>()
                .Property(e => e.wfnMaxNum)
                .HasPrecision(18, 0);

            modelBuilder.Entity<wfWorkNodes>()
                .HasMany(e => e.wfProcess)
                .WithRequired(e => e.wfWorkNodes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<wfWorkNodes>()
                .HasMany(e => e.wfWorkBranch)
                .WithRequired(e => e.wfWorkNodes)
                .HasForeignKey(e => e.wfnID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<wfWorkNodes>()
                .HasMany(e => e.wfWorkBranch1)
                .WithRequired(e => e.wfWorkNodes1)
                .HasForeignKey(e => e.wfNodeID)
                .WillCascadeOnDelete(false);
        }
    }
}
