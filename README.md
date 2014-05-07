Mock All The Things
=======

Intro
-----

A very basic auto-mocker. Currently supports Moq, RhinoMocks and FakeItEasy as sources for mocks.

Setup
-----

```
Create.UsingProvider(new MoqMockProvider());
```
or
```
Create.UsingProvider(new RhinoMocksMockProvider());
```
or
```
Create.UsingProvider(new FakeItEasyMockProvider());
```

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
