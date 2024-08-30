public static class Helper {
    public static T GetRandom<T>(params T[] arr)
    {
        if (arr == null || arr.Length <= 0) return default;

        return arr[UnityEngine.Random.Range(0, arr.Length)];
    }
}
