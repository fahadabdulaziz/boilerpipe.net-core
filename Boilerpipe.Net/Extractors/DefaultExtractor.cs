namespace Boilerpipe.Net.Extractors
{
    using Document;
    using Filters.English;
    using Filters.Heuristics;

    /// <summary>
    ///   A quite generic full-text extractor.
    /// </summary>
    public class DefaultExtractor : BaseExtractor
    {
        /// <summary>
        ///   The singleton instance for <see cref="DefaultExtractor" />
        /// </summary>
        public static readonly DefaultExtractor Instance = new DefaultExtractor();

        public override bool Process(TextDocument doc)
        {
            return SimpleBlockFusionProcessor.Instance.Process(doc)
                   | BlockProximityFusion.MaxDistance1.Process(doc)
                   | DensityRulesClassifier.Instance.Process(doc);
        }
    }
}
