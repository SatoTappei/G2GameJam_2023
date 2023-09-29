using UnityEngine;

public enum GearStep
{
    One = 1,
    Two = 2,
    Three = 3,
}

public class GearView : MonoBehaviour
{
    [SerializeField] Transform _cursor;
    [SerializeField] GameObject _concentration;
    [SerializeField] float _angle1 = 66.0f;
    [SerializeField] float _angle2 = 0;
    [SerializeField] float _angle3 = -66.0f;

    public void Change(GearStep gear)
    {
        float angle = 0;
        if (gear == GearStep.One) angle = _angle1;
        if (gear == GearStep.Two) angle = _angle2;
        if (gear == GearStep.Three) angle = _angle3;
        _cursor.transform.eulerAngles = new Vector3(0, 0, angle);

        // ギア3の場合、集中線を表示
        _concentration.SetActive(gear == GearStep.Three);
    }

    public static GearStep Increment(GearStep step)
    {
        int value = (int)step;
        return (GearStep)Mathf.Clamp(++value, 1, 3);
    }

    public static GearStep Decrement(GearStep step)
    {
        int value = (int)step;
        return (GearStep)Mathf.Clamp(--value, 1, 3);
    }
}
