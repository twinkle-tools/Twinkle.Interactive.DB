using System;
using System.Threading.Tasks;
using DBService.Repositories.DBContext;

namespace DBService.Repositories.UnitOfWork
{
    public class DbUnitOfWork:IDisposable
    {
        private readonly DbServiceContext _dbServiceContext = new DbServiceContext();
        
        private ControlRepository _controlRepository;
        private MethodParamRepository _methodParamRepository;
        private MethodRepository _methodRepository;
        private ProjectRepository _projectRepository;
        private TableColumnRepository _tableColumnRepository;
        private TreatmentOptionRepository _treatmentOptionRepository;
        private TypeControlRepository _typeControlRepository;
        private ViewDefinitionCriteriaRepository _viewDefinitionCriteriaRepository;
        private ViewDefinitionCriteriaParamRepository _viewDefinitionCriteriaParamRepository;

        private bool _disposed;

        public ControlRepository Controls
        {
            get
            {
                if (_controlRepository == null)
                    _controlRepository = new ControlRepository(_dbServiceContext);
                return _controlRepository;
            }
        }
        
        public MethodParamRepository MethodParams
        {
            get
            {
                if (_methodParamRepository == null)
                    _methodParamRepository = new MethodParamRepository(_dbServiceContext);
                return _methodParamRepository;
            }
        }
        
        public MethodRepository Methods
        {
            get
            {
                if (_methodRepository == null)
                    _methodRepository = new MethodRepository(_dbServiceContext);
                return _methodRepository;
            }
        }
        
        public ProjectRepository Projects
        {
            get
            {
                if (_projectRepository == null)
                    _projectRepository = new ProjectRepository(_dbServiceContext);
                return _projectRepository;
            }
        }
        
        public TableColumnRepository TablesColumns
        {
            get
            {
                if (_tableColumnRepository == null)
                    _tableColumnRepository = new TableColumnRepository(_dbServiceContext);
                return _tableColumnRepository;
            }
        }
        
        public TreatmentOptionRepository TreatmentOptions
        {
            get
            {
                if (_treatmentOptionRepository == null)
                    _treatmentOptionRepository = new TreatmentOptionRepository(_dbServiceContext);
                return _treatmentOptionRepository;
            }
        }
        
        public TypeControlRepository TypesControls
        {
            get
            {
                if (_typeControlRepository == null)
                    _typeControlRepository = new TypeControlRepository(_dbServiceContext);
                return _typeControlRepository;
            }
        }
        
        public ViewDefinitionCriteriaRepository ViewDefinitionCriteria
        {
            get
            {
                if (_viewDefinitionCriteriaRepository == null)
                    _viewDefinitionCriteriaRepository = new ViewDefinitionCriteriaRepository(_dbServiceContext);
                return _viewDefinitionCriteriaRepository;
            }
        }
        
        public ViewDefinitionCriteriaParamRepository ViewDefinitionCriteriaParam
        {
            get
            {
                if (_viewDefinitionCriteriaParamRepository == null)
                    _viewDefinitionCriteriaParamRepository = new ViewDefinitionCriteriaParamRepository(_dbServiceContext);
                return _viewDefinitionCriteriaParamRepository;
            }
        }
        
        public Task SaveChangesAsync()
        {
            return _dbServiceContext.SaveChangesAsync();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbServiceContext.Dispose();
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}