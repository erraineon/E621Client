# E621Client
example
```csharp
//obtains the image urls of five random posts containing tags 'cute' and 'dragon'
var client = new E621Client("test/errai");
var posts = await client.Search(new E621SearchOptions
{
    Tags = "cute dragon order:random",
    Limit = 5,
});
var postUrls = posts
    .Select(post => post.FileUrl)
    .ToList();
```

implements a rate limiter to throttle requests at one per second
