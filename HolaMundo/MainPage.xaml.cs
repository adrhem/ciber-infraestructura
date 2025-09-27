using System.Text.RegularExpressions;

namespace HolaMundo;

public partial class MainPage : ContentPage
{

	/**
		*	[a-zA-Z0-9_]: cualquier letra mayúscula o minúscula, número o guion bajo
		*	{4,}: al menos 4 caracteres
	  */
	private Regex usernamePattern = new Regex("^[a-zA-Z0-9_]{4,}$");

	/**
	  * (?=.*[A-Z]): al menos una letra mayúscula
		*	(?=.*[a-z]): al menos una letra minúscula
		*	(?=.*\\d): al menos un número
		*	(?=.*[!@#$%^&*]): al menos un carácter especial
		*	.{4,}: mínimo de 4 caracteres
	  */
	private Regex passwordPattern = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*]).{4,}$");

	public MainPage()
	{
		InitializeComponent();
		Title = "Iniciar sesión";
	}

	private void OnLoginButtonClicked(object? sender, EventArgs e)
	{
		string username = (UsernameEntry.Text ?? "").Trim().ToLower();
		string password = (PasswordEntry.Text ?? "").Trim();

		if (!usernamePattern.IsMatch(username))
		{
			ValidationLabel.Text = "El nombre de usuario no es válido. Debe tener al menos 3 caracteres y solo contener letras, números y guiones bajos.";
			ValidationLabel.TextColor = Colors.Tomato;
			return;
		}

		if (!passwordPattern.IsMatch(password))
		{
			ValidationLabel.Text = "La contraseña no es válida. Debe tener al menos 4 caracteres y contener al menos una letra minuscula, una mayuscula, un número y un símbolo.";
			ValidationLabel.TextColor = Colors.Tomato;
			return;
		}

		ValidationLabel.Text = string.Format("¡Bienvenido, {0}!", username);
		ValidationLabel.TextColor = Colors.Green;
	}

	private void UsernamePasswordEntry_HandlerChanged(object sender, EventArgs e)
	{
		ValidationLabel.Text = "";
		ValidationLabel.TextColor = Colors.Green;
  }
}
