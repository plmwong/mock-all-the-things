Mock All The Things
=======

Intro
-----

Basically a simple auto-mocker. Currently supports Moq and RhinoMocks.

Usage
-----

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

### Providing and instance for a type

```
Create.MeA<Foo>()
	.UsingThisInstanceToMock<IBar>(instanceOfBar)
        .AndMockingAllTheOtherThings();
```

### Providing and instance for a specific parameter

```
Create.MeA<Foo>()
	.UsingThisInstanceToMock<IBar>(instanceOfBar)
	.SpecificallyForTheArgumentAt(1)
        .AndMockingAllTheOtherThings();
```
