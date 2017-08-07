namespace ViewModel.Main
{
	using Common.Attributes;

	public enum TestEnum
	{
		[DescriptionKey("TestEnumOne")] One,
		[DescriptionKey("TestEnumTwo")] Two,
		[DescriptionKey("TestEnumThree")] Three
	}
}