using CSharp.Experiments.Cryptography;
using CSharp.Experiments.Cryptography.Commands;
using CSharp.Experiments.Cryptography.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

var cts = new CancellationTokenSource();

builder.Services.AddSingleton<IKeyGenerator, KeyGenerator>();
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();
builder.Services.AddSingleton<ICommand, GenerateKeyCommand>();
builder.Services.AddSingleton<ICommand, EncryptCommand>();
builder.Services.AddSingleton<ICommand, DecryptCommand>();
builder.Services.AddSingleton<ICommand, ExitCommand>(_ => new ExitCommand(cts));
builder.Services.AddSingleton<ICommandProvider, CommandProvider>();
builder.Services.AddSingleton<ICommandHandler, CommandHandler>();

using var host = builder.Build();

var commandHandler = host.Services.GetRequiredService<ICommandHandler>();

_ = Task.Run(() => commandHandler.HandleAsync(cts.Token));

await host.RunAsync(cts.Token);
