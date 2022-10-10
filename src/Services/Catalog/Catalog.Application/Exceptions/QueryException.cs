﻿namespace Catalog.Application.Exceptions;

public class QueryException : Exception
{
    public QueryException()
    {
    }

    public QueryException(string message) : base(message)
    {
    }
}