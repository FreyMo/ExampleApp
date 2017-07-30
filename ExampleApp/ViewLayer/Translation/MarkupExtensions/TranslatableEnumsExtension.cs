namespace ViewLayer.Translation.MarkupExtensions
{
	using System;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Markup;
	using Common.ArgumentMust;
	using Common.Extensions;
	using global::Translation.TranslatableEnum;

	public class TranslatableEnumsExtension : MarkupExtension
	{
		private readonly Binding _binding;
		private ComboBox _comboBox;

		public TranslatableEnumsExtension(Type enumType)
		{
			ArgumentMust.BeEnum(() => enumType);

			_binding = new Binding(nameof(TranslatableEnumAdapter.Values))
			{
				Source = new TranslatableEnumAdapter(enumType)
			};

			_binding.Source.Cast<TranslatableEnumAdapter>().PropertyChanged += UpdateSelection;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			SetSelectedValuePath(serviceProvider);

			return _binding.ProvideValue(serviceProvider);
		}

		private void SetSelectedValuePath(IServiceProvider serviceProvider)
		{
			var target = serviceProvider.GetService(typeof(IProvideValueTarget)).As<IProvideValueTarget>();
			if (target?.TargetObject is ComboBox)
			{
				_comboBox = target.TargetObject.Cast<ComboBox>();
				_comboBox.DisplayMemberPath = nameof(TranslatableEnumValue.TranslatedName);
				_comboBox.SelectedValuePath = nameof(TranslatableEnumValue.Value);
			}
		}

		private void UpdateSelection(object sender, EventArgs e)
		{
			// The dirty way
			var formerIndex = _comboBox.SelectedIndex;
			_comboBox.SelectedIndex = -1;
			_comboBox.SelectedIndex = formerIndex;
		}
	}
}