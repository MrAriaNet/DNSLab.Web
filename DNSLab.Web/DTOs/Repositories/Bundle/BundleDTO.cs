namespace DNSLab.Web.DTOs.Repositories.Bundle
{
    public class BundleDTO
    {
        public Guid Id { get; set; }
        public List<BundleFeatureDTO> Features { get; set; }
        public BundleDurationDTO Duration { get; set; }
    }
}
