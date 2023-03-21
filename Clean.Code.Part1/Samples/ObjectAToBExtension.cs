namespace Clean.Code.Part1.Samples
{
    public static class ObjectAToBExtension
    {
        // Is a extension now a good solution ?
        // - What happens when we need https://www.nuget.org/packages/AutoMapper or another service for a complex mapping ?
        // - What if we want to log mapping infos anywhere, imagine enum mappings, undefined and more ?
        // => With extensions you are not able to consume registered services ! Without any dirty hacks !
        public static ObjectB ToObjectB(this ObjectA source)
        {
            return new ObjectB()
            {
                PropertyA = source.PropertyB,
                PropertyB = source.PropertyA
            };
        }
    }
}
