﻿global using DoroTech.BookStore.Application.PipelineBehaviors;
global using DoroTech.BookStore.Application.RequestHandlers.CommandHandlers;
global using DoroTech.BookStore.Contracts.Requests.Commands.Auth;
global using DoroTech.BookStore.Domain.Aggregates;
global using DoroTech.BookStore.Domain;
global using DoroTech.BookStore.Application.Common.Interfaces.Services;
global using DoroTech.BookStore.Application.Common;
global using DoroTech.BookStore.Application.Exceptions;
global using DoroTech.BookStore.Application.Repositories;
global using DoroTech.BookStore.Contracts.Responses.Auth;
global using DoroTech.BookStore.Contracts;
global using DoroTech.BookStore.Contracts.Requests.Queries;
global using DoroTech.BookStore.Contracts.Requests.Commands;


global using System.Linq.Expressions;
global using System.Reflection;
global using FluentValidation;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection;
global using FluentValidation.Results;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;
global using OperationResult;
global using MapsterMapper;
