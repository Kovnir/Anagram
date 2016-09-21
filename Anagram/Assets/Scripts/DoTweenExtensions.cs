// Decompiled with JetBrains decompiler
// Type: DG.Tweening.DoTweenExtensions
// Assembly: DOTween46, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109BC76-1EA1-4914-B8F0-61B8B19DDA59
// Assembly location: E:\Projects\gaming-deadly-run\Assets\Frameworks\DOTween\DOTween46.dll

using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
  /// <summary>
  /// Methods that extend known Unity objects and allow to directly create and control tweens from their instances.
  ///             These, as all DOTween46 methods, require Unity 4.6 or later.
  /// 
  /// </summary>
  public static class DoTweenExtensions
  {
    /// <summary>
    /// Tweens a CanvasGroup's alpha Color to the given value.
    ///             Also stores the canvasGroup as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
    public static Tweener DOFade(this CanvasGroup target, float endValue, float duration)
    {
      return (Tweener) TweenSettingsExtensions.SetTarget<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>) (() => target.alpha), (DOSetter<float>) (x => target.alpha = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens an Graphic's Color to the given value.
    ///             Also stores the image as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
    public static Tweener DOColor(this Graphic target, Color endValue, float duration)
    {
      return (Tweener) TweenSettingsExtensions.SetTarget<TweenerCore<Color, Color, ColorOptions>>(DOTween.To((DOGetter<Color>) (() => target.color), (DOSetter<Color>) (x => target.color = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens an Graphic's alpha Color to the given value.
    ///             Also stores the image as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
    public static Tweener DOFade(this Graphic target, float endValue, float duration)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(DOTween.ToAlpha((DOGetter<Color>) (() => target.color), (DOSetter<Color>) (x => target.color = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens an Image's Color to the given value.
    ///             Also stores the image as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
    public static Tweener DOColor(this Image target, Color endValue, float duration)
    {
      return (Tweener) TweenSettingsExtensions.SetTarget<TweenerCore<Color, Color, ColorOptions>>(DOTween.To((DOGetter<Color>) (() => target.color), (DOSetter<Color>) (x => target.color = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens an Image's alpha Color to the given value.
    ///             Also stores the image as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
    public static Tweener DOFade(this Image target, float endValue, float duration)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(DOTween.ToAlpha((DOGetter<Color>) (() => target.color), (DOSetter<Color>) (x => target.color = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens an Image's fillAmount to the given value.
    ///             Also stores the image as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach (0 to 1)</param><param name="duration">The duration of the tween</param>
    public static Tweener DOFillAmount(this Image target, float endValue, float duration)
    {
      if ((double) endValue > 1.0)
        endValue = 1f;
      else if ((double) endValue < 0.0)
        endValue = 0.0f;
      return (Tweener) TweenSettingsExtensions.SetTarget<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>) (() => target.fillAmount), (DOSetter<float>) (x => target.fillAmount = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens an LayoutElement's flexibleWidth/Height to the given value.
    ///             Also stores the LayoutElement as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
    public static Tweener DOFlexibleSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(TweenSettingsExtensions.SetOptions(DOTween.To((DOGetter<Vector2>) (() => new Vector2(target.flexibleWidth, target.flexibleHeight)), (DOSetter<Vector2>) (x =>
      {
        target.flexibleWidth = x.x;
        target.flexibleHeight = x.y;
      }), endValue, duration), snapping), (object) target);
    }

    /// <summary>
    /// Tweens an LayoutElement's minWidth/Height to the given value.
    ///             Also stores the LayoutElement as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
    public static Tweener DOMinSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(TweenSettingsExtensions.SetOptions(DOTween.To((DOGetter<Vector2>) (() => new Vector2(target.minWidth, target.minHeight)), (DOSetter<Vector2>) (x =>
      {
        target.minWidth = x.x;
        target.minHeight = x.y;
      }), endValue, duration), snapping), (object) target);
    }

    /// <summary>
    /// Tweens an LayoutElement's preferredWidth/Height to the given value.
    ///             Also stores the LayoutElement as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
    public static Tweener DOPreferredSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(TweenSettingsExtensions.SetOptions(DOTween.To((DOGetter<Vector2>) (() => new Vector2(target.preferredWidth, target.preferredHeight)), (DOSetter<Vector2>) (x =>
      {
        target.preferredWidth = x.x;
        target.preferredHeight = x.y;
      }), endValue, duration), snapping), (object) target);
    }

    /// <summary>
    /// Tweens a Outline's effectColor to the given value.
    ///             Also stores the Outline as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
    public static Tweener DOColor(this Outline target, Color endValue, float duration)
    {
      return (Tweener) TweenSettingsExtensions.SetTarget<TweenerCore<Color, Color, ColorOptions>>(DOTween.To((DOGetter<Color>) (() => target.effectColor), (DOSetter<Color>) (x => target.effectColor = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens a Outline's effectColor alpha to the given value.
    ///             Also stores the Outline as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
    public static Tweener DOFade(this Outline target, float endValue, float duration)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(DOTween.ToAlpha((DOGetter<Color>) (() => target.effectColor), (DOSetter<Color>) (x => target.effectColor = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens a Outline's effectDistance to the given value.
    ///             Also stores the Outline as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
    public static Tweener DOScale(this Outline target, Vector2 endValue, float duration)
    {
      return (Tweener) TweenSettingsExtensions.SetTarget<TweenerCore<Vector2, Vector2, VectorOptions>>(DOTween.To((DOGetter<Vector2>) (() => target.effectDistance), (DOSetter<Vector2>) (x => target.effectDistance = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens a RectTransform's anchoredPosition to the given value.
    ///             Also stores the RectTransform as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
    public static Tweener DOAnchorPos(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(TweenSettingsExtensions.SetOptions(DOTween.To((DOGetter<Vector2>) (() => target.anchoredPosition), (DOSetter<Vector2>) (x => target.anchoredPosition = x), endValue, duration), snapping), (object) target);
    }

    /// <summary>
    /// Tweens a RectTransform's anchoredPosition3D to the given value.
    ///             Also stores the RectTransform as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
    public static Tweener DOAnchorPos3D(this RectTransform target, Vector3 endValue, float duration, bool snapping = false)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(TweenSettingsExtensions.SetOptions(DOTween.To((DOGetter<Vector3>) (() => target.anchoredPosition3D), (DOSetter<Vector3>) (x => target.anchoredPosition3D = x), endValue, duration), snapping), (object) target);
    }

    /// <summary>
    /// Tweens a RectTransform's sizeDelta to the given value.
    ///             Also stores the RectTransform as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
    public static Tweener DOSizeDelta(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(TweenSettingsExtensions.SetOptions(DOTween.To((DOGetter<Vector2>) (() => target.sizeDelta), (DOSetter<Vector2>) (x => target.sizeDelta = x), endValue, duration), snapping), (object) target);
    }

    /// <summary>
    /// Punches a RectTransform's anchoredPosition towards the given direction and then back to the starting one
    ///             as if it was connected to the starting position via an elastic.
    ///             Also stores the RectTransform as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="punch">The direction and strength of the punch (added to the RectTransform's current position)</param><param name="duration">The duration of the tween</param><param name="vibrato">Indicates how much will the punch vibrate</param><param name="elasticity">Represents how much (0 to 1) the vector will go beyond the starting position when bouncing backwards.
    ///             1 creates a full oscillation between the punch direction and the opposite direction,
    ///             while 0 oscillates only between the punch and the start position</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
    public static Tweener DOPunchAnchorPos(this RectTransform target, Vector2 punch, float duration, int vibrato = 10, float elasticity = 1f, bool snapping = false)
    {
      return TweenSettingsExtensions.SetOptions(TweenSettingsExtensions.SetTarget<TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>>(DOTween.Punch((DOGetter<Vector3>) (() => (Vector3) target.anchoredPosition), (DOSetter<Vector3>) (x => target.anchoredPosition = (Vector2) x), (Vector3) punch, duration, vibrato, elasticity), (object) target), snapping);
    }
        /*
            /// <summary>
            /// Shakes a RectTransform's anchoredPosition with the given values.
            ///             Also stores the RectTransform as the tween's target so it can be used for filtered operations
            /// </summary>
            /// <param name="duration">The duration of the tween</param><param name="strength">The shake strength</param><param name="vibrato">Indicates how much will the shake vibrate</param><param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware).
            ///             Setting it to 0 will shake along a single direction.</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
            public static Tweener DOShakeAnchorPos(this RectTransform target, float duration, float strength = 100f, int vibrato = 10, float randomness = 90f, bool snapping = false)
            {
              return TweenSettingsExtensions.SetOptions(Extensions.SetSpecialStartupMode<TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>>(TweenSettingsExtensions.SetTarget<TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>>(DOTween.Shake((DOGetter<Vector3>) (() => (Vector3) target.anchoredPosition), (DOSetter<Vector3>) (x => target.anchoredPosition = (Vector2) x), duration, strength, vibrato, randomness, true), (object) target), SpecialStartupMode.SetShake), snapping);
            }
            /// <summary>
            /// Shakes a RectTransform's anchoredPosition with the given values.
            ///             Also stores the RectTransform as the tween's target so it can be used for filtered operations
            /// </summary>
            /// <param name="duration">The duration of the tween</param><param name="strength">The shake strength on each axis</param><param name="vibrato">Indicates how much will the shake vibrate</param><param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware).
            ///             Setting it to 0 will shake along a single direction.</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
            public static Tweener DOShakeAnchorPos(this RectTransform target, float duration, Vector2 strength, int vibrato = 10, float randomness = 90f, bool snapping = false)
            {
              return TweenSettingsExtensions.SetOptions(Extensions.SetSpecialStartupMode<TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>>(TweenSettingsExtensions.SetTarget<TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>>(DOTween.Shake((DOGetter<Vector3>) (() => (Vector3) target.anchoredPosition), (DOSetter<Vector3>) (x => target.anchoredPosition = (Vector2) x), duration, (Vector3) strength, vibrato, randomness), (object) target), SpecialStartupMode.SetShake), snapping);
            }

        /// <summary>
        /// Tweens a RectTransform's anchoredPosition to the given value, while also applying a jump effect along the Y axis.
        ///             Returns a Sequence instead of a Tweener.
        ///             Also stores the RectTransform as the tween's target so it can be used for filtered operations
        /// </summary>
        /// <param name="endValue">The end value to reach</param><param name="jumpPower">Power of the jump (the max height of the jump is represented by this plus the final Y offset)</param><param name="numJumps">Total number of jumps</param><param name="duration">The duration of the tween</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Sequence DOJumpAnchorPos(this RectTransform target, Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
    {
      if (numJumps < 1)
        numJumps = 1;
      float startPosY = target.anchoredPosition.y;
      float offsetY = -1f;
      bool offsetYSet = false;
      Sequence s = TweenSettingsExtensions.SetEase<Sequence>(TweenSettingsExtensions.SetTarget<Sequence>(TweenSettingsExtensions.Join(TweenSettingsExtensions.Append(DOTween.Sequence(), (Tween) TweenSettingsExtensions.SetEase<Tweener>(TweenSettingsExtensions.SetOptions(DOTween.To((DOGetter<Vector2>) (() => target.anchoredPosition), (DOSetter<Vector2>) (x => target.anchoredPosition = x), new Vector2(endValue.x, 0.0f), duration), AxisConstraint.X, snapping), Ease.Linear)), (Tween) TweenSettingsExtensions.SetRelative<Tweener>(TweenSettingsExtensions.SetLoops<Tweener>(TweenSettingsExtensions.SetEase<Tweener>(TweenSettingsExtensions.SetOptions(DOTween.To((DOGetter<Vector2>) (() => target.anchoredPosition), (DOSetter<Vector2>) (x => target.anchoredPosition = x), new Vector2(0.0f, jumpPower), duration / (float) (numJumps * 2)), AxisConstraint.Y, snapping), Ease.OutQuad), numJumps * 2, LoopType.Yoyo))), (object) target), DOTween.defaultEaseType);
      TweenSettingsExtensions.OnUpdate<Sequence>(s, (TweenCallback) (() =>
      {
        if (!offsetYSet)
        {
          offsetYSet = false;
          offsetY = s.isRelative ? endValue.y : endValue.y - startPosY;
        }
        Vector2 anchoredPosition = target.anchoredPosition;
        anchoredPosition.y += DOVirtual.EasedValue(0.0f, offsetY, TweenExtensions.ElapsedDirectionalPercentage((Tween) s), Ease.OutQuad);
        target.anchoredPosition = anchoredPosition;
      }));
      return s;
    }
            */

        /// <summary>
        /// Tweens a Slider's value to the given value.
        ///             Also stores the Slider as the tween's target so it can be used for filtered operations
        /// </summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param><param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOValue(this Slider target, float endValue, float duration, bool snapping = false)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(TweenSettingsExtensions.SetOptions(DOTween.To((DOGetter<float>) (() => target.value), (DOSetter<float>) (x => target.value = x), endValue, duration), snapping), (object) target);
    }

    /// <summary>
    /// Tweens a Text's Color to the given value.
    ///             Also stores the Text as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
    public static Tweener DOColor(this Text target, Color endValue, float duration)
    {
      return (Tweener) TweenSettingsExtensions.SetTarget<TweenerCore<Color, Color, ColorOptions>>(DOTween.To((DOGetter<Color>) (() => target.color), (DOSetter<Color>) (x => target.color = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens a Text's alpha Color to the given value.
    ///             Also stores the Text as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
    public static Tweener DOFade(this Text target, float endValue, float duration)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(DOTween.ToAlpha((DOGetter<Color>) (() => target.color), (DOSetter<Color>) (x => target.color = x), endValue, duration), (object) target);
    }

    /// <summary>
    /// Tweens a Text's text to the given value.
    ///             Also stores the Text as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The end string to tween to</param><param name="duration">The duration of the tween</param><param name="richTextEnabled">If TRUE (default), rich text will be interpreted correctly while animated,
    ///             otherwise all tags will be considered as normal text</param><param name="scrambleMode">The type of scramble mode to use, if any</param><param name="scrambleChars">A string containing the characters to use for scrambling.
    ///             Use as many characters as possible (minimum 10) because DOTween uses a fast scramble mode which gives better results with more characters.
    ///             Leave it to NULL (default) to use default ones</param>
    public static Tweener DOText(this Text target, string endValue, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
    {
      return TweenSettingsExtensions.SetTarget<Tweener>(TweenSettingsExtensions.SetOptions(DOTween.To((DOGetter<string>) (() => target.text), (DOSetter<string>) (x => target.text = x), endValue, duration), richTextEnabled, scrambleMode, scrambleChars), (object) target);
    }
        /*
    /// <summary>
    /// Tweens a Graphic's Color to the given value,
    ///             in a way that allows other DOBlendableColor tweens to work together on the same target,
    ///             instead than fight each other as multiple DOColor would do.
    ///             Also stores the Graphic as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The value to tween to</param><param name="duration">The duration of the tween</param>
    public static Tweener DOBlendableColor(this Graphic target, Color endValue, float duration)
    {
      endValue -= target.color;
      Color to = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      return (Tweener) TweenSettingsExtensions.SetTarget<TweenerCore<Color, Color, ColorOptions>>(Extensions.Blendable<Color, Color, ColorOptions>(DOTween.To((DOGetter<Color>) (() => to), (DOSetter<Color>) (x =>
      {
        Color color = x - to;
        to = x;
        Graphic graphic = target;
        graphic.color = graphic.color + color;
      }), endValue, duration)), (object) target);
    }
    /// <summary>
    /// Tweens a Image's Color to the given value,
    ///             in a way that allows other DOBlendableColor tweens to work together on the same target,
    ///             instead than fight each other as multiple DOColor would do.
    ///             Also stores the Image as the tween's target so it can be used for filtered operations
    /// </summary>
    /// <param name="endValue">The value to tween to</param><param name="duration">The duration of the tween</param>
    public static Tweener DOBlendableColor(this Image target, Color endValue, float duration)
    {
      endValue -= target.color;
      Color to = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      return (Tweener) TweenSettingsExtensions.SetTarget<TweenerCore<Color, Color, ColorOptions>>(Extensions.Blendable<Color, Color, ColorOptions>(DOTween.To((DOGetter<Color>) (() => to), (DOSetter<Color>) (x =>
      {
        Color color = x - to;
        to = x;
        Image image = target;
        image.color = image.color + color;
      }), endValue, duration)), (object) target);
    }
    
        /// <summary>
        /// Tweens a Text's Color BY the given value,
        ///             in a way that allows other DOBlendableColor tweens to work together on the same target,
        ///             instead than fight each other as multiple DOColor would do.
        ///             Also stores the Text as the tween's target so it can be used for filtered operations
        /// </summary>
        /// <param name="endValue">The value to tween to</param><param name="duration">The duration of the tween</param>
        public static Tweener DOBlendableColor(this Text target, Color endValue, float duration)
    {
      endValue -= target.color;
      Color to = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      return (Tweener) TweenSettingsExtensions.SetTarget<TweenerCore<Color, Color, ColorOptions>>(Extensions.Blendable<Color, Color, ColorOptions>(DOTween.To((DOGetter<Color>) (() => to), (DOSetter<Color>) (x =>
      {
        Color color = x - to;
        to = x;
        Text text = target;
        text.color = text.color + color;
      }), endValue, duration)), (object) target);
    }
    
    */
    }
}
