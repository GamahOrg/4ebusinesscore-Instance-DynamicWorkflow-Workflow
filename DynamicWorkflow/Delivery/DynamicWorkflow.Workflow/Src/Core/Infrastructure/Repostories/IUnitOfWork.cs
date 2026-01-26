namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Guid _loggedInUserId { get; }
        #region Transaction
        void BeginTransaction();
        void Commit();
        void Rollback();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        #endregion
        #region SaveChanges
        Task SaveChangesAsync();
        void SaveChanges();
        void SaveChanges(Guid creatBy);
        #endregion
    }
}
