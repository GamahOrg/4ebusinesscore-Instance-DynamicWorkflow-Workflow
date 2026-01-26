using RiskManagement.Application.Protos.Risk;

namespace _4EPlatform_DynamicWorkflow_Aggregator.GrpClientsConfig
{

    public static class GrpcClients
    {

        #region DynmaicWorkFlowAggregator
        public static void AddDynamicWorkFlowAggClients(this IServiceCollection services, string url)
        {
            services.AddGrpcServiceClient<RequestTemplateStepProtoService.RequestTemplateStepProtoServiceClient>(url);

        }
        #endregion

        #region UserManagement
        public static void AddUserManagementGrpcClients(
            this IServiceCollection services,
            string userManagmentUrl)
        {
            services.AddGrpcServiceClient<PermissionGroupingService.PermissionGroupingServiceClient>(userManagmentUrl);
            services.AddGrpcServiceClient<DelegationUserProtoService.DelegationUserProtoServiceClient>(userManagmentUrl);
            services.AddGrpcServiceClient<UserProtoService.UserProtoServiceClient>(userManagmentUrl);
        }
        #endregion
        #region Commite

        public static void AddCommiteGrpcClients(
          this IServiceCollection services,
          string CommitteeUrl)
        {
            services.AddGrpcServiceClient<CommitteeProtoService.CommitteeProtoServiceClient>(CommitteeUrl);
        }
        #endregion

        #region Pmo
        public static void AddPmoGrpcClients(this IServiceCollection services, string url)
        {
            services.AddGrpcServiceClient<ProjectServices.ProjectServicesClient>(url);
            services.AddGrpcServiceClient<ChangeServices.ChangeServicesClient>(url);
            services.AddGrpcServiceClient<BidRequestProtoService.BidRequestProtoServiceClient>(url);
            services.AddGrpcServiceClient<ProjectStudyProtoService.ProjectStudyProtoServiceClient>(url);
        }
        #endregion

        #region Training
        public static void AddTrainingGrpcClients(this IServiceCollection services, string url)
        {
            services.AddGrpcServiceClient<TrainingProtoService.TrainingProtoServiceClient>(url);

        }
        #endregion
        #region Risk
        public static void AddRiskGrpcClients(this IServiceCollection services, string url)
        {
            services.AddGrpcServiceClient<RiskDynamicProtoService.RiskDynamicProtoServiceClient>(url);

        }
        #endregion
    }
}
