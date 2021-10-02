using UnityEngine;

namespace DefaultNamespace
{
    public static class AnimatorExtension
    {
        public static AnimationClip FindAnimation(this Animator animator, string name)
        {
            var avatarController = animator.runtimeAnimatorController;

            foreach (var animation in avatarController.animationClips)
            {
                if (animation.name.Equals(name))
                {
                    return animation;
                }
            }

            return null;
        }
    }
}