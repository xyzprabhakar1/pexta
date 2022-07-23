using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using projMasters.Database;

namespace pextaApi
{
    public class AccessRightRequirement : IAuthorizationRequirement
    {
        public bool IsValidateOrganisation;
        public enmDocumentMaster documentMaster;
        public enmDocumentType documentType;
        public enmAdditionalClaim additionalClaim;
        public AccessRightRequirement(enmDocumentMaster documentMaster,
            enmDocumentType documentType, enmAdditionalClaim additionalClaim)
        {
            IsValidateOrganisation = false;
            this.documentMaster = documentMaster;
            this.documentType = documentType;
            this.additionalClaim = additionalClaim;
        }        
    }
    public class AccessRightHandler : AuthorizationHandler<AccessRightRequirement>
    {
        private readonly MasterContext _Dbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccessRightHandler(MasterContext Dbcontext, IHttpContextAccessor httpContextAccessor)
        {
            _Dbcontext = Dbcontext;
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessRightRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "__UserId"))
            {
                uint UserId = 0;
                uint.TryParse(context.User.Claims.Where(p => p.Type == "__UserId").FirstOrDefault()?.Value, out UserId);
                if (_Dbcontext.tblUserAllClaim.Where(p => p.UserId == UserId && p.DocumentMaster == requirement.documentMaster
                && p.DocumentType == requirement.documentType && p.AdditionalClaim == requirement.additionalClaim).Any())
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
