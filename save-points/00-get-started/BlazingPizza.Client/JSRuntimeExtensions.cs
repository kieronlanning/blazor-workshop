using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza.Client
{
	static public class JSRuntimeExtensions
	{
		static public ValueTask<bool> ConfirmAsync(this IJSRuntime jsRuntime, string message)
		{
			return jsRuntime.InvokeAsync<bool>("confirm", message);
		}
	}
}
