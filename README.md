Mock All The Things
=======

Intro
-----

Basically a simple auto-mocker. Currently supports Moq and RhinoMocks.

Usage
-----

### Setup

```
Create.UsingProvider(new MoqMockProvider());
```
or
```
Create.UsingProvider(new RhinoMocksMockProvider());
```

```
public class Foo(IBar bar1, IBar bar2, IBaz baz) {
       ...
}
```

### Mock everything

```
Create.MeA<Foo>()
	.MockingAllTheThings();
```

### Providing an instance for a type

Note: This will affect all instances of the type (unless a specific parameter is targetted).

```
Create.MeA<Foo>()
	.UsingThisInstanceToMock<IBar>(instanceOfBar)
        .AndMockingAllTheOtherThings();
```

### Providing an instance for a specific parameter

```
Create.MeA<Foo>()
	.UsingThisInstanceToMock<IBar>(instanceOfBar)
	.SpecificallyForTheArgumentAt(1)
        .AndMockingAllTheOtherThings();
```
