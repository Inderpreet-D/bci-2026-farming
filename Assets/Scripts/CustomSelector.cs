using UnityEngine;

namespace BCIEssentials.Selection
{
    using Extensions;
    using LSLFramework;
    using Stimulus.Collections;
    using Stimulus.Presentation;

    public class CustomSelector : SelectionBehaviour
    {
        [SerializeField]
        private StimulusPresenterCollection _target;

        private void Reset() => this.CoalesceComponentReference(ref _target);
        private void Start() => this.CoalesceComponentReference(ref _target);

        public override void OnPrediction(Prediction prediction)
        {
            var presenter = _target.LatestSubset[prediction.Index];
            Debug.Log($"Selected {presenter.name} with prediction index {prediction.Index}");
            presenter.Select();
            presenter.GetComponentInChildren<SpriteGridCell>().OnMouseDown();
        }
    }
}