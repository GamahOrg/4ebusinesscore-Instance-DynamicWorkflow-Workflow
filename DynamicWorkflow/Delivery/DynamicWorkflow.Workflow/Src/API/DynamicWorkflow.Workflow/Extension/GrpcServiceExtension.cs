
namespace DynamicWorkflow.Workflow.Extension
{
    public static class GrpcServiceExtension
    {
        public static void AddgRPCServices(this WebApplication app)
        {
            app.MapGrpcService<RequestTemplateService>();
            app.MapGrpcService<RequestInstanceService>();
            app.MapGrpcService<WorkflowControllerInfoService>();
            app.MapGrpcService<DefaultExceptionActionTackersService>();
            app.MapGrpcService<AssginRequsetService>();


        }

    }
}
