Generate constructor and update methods  for  Lookup/Handle structures

Also supports EntityStorageLookup/Handle
Also works with structs placed inside system. 
Also supports managed systems [AutoLookups(true)]

```csharp


namespace MyNamespace
{
    [BurstCompile]
    [AutoLookups]
    public partial struct LookupsX
    {
        public ComponentLookup<LocalTransform> lookup;
        public ComponentLookup<LocalTransform> lookup2;
        [ReadOnly] public ComponentLookup<LocalToWorld> lookup3;
       // Another parts will be generated
    }
    
    [BurstCompile]
    partial struct SystemNa222meSystem : ISystem
    {
        private LookupsX _lookupsX;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _lookupsX = new LookupsX(ref state);
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            _lookupsX.Update(ref state);
        }

    }
}

```

And it will generate partial structs for you

```csharp
 public partial struct LookupsX
    {

        public LookupsX(ref SystemState state):this()
        {
            lookup = state.GetComponentLookup<LocalTransform>(false);
lookup2 = state.GetComponentLookup<LocalTransform>(false);
lookup3 = state.GetComponentLookup<LocalToWorld>(true);
        }

        public void Update(ref SystemState state)
        {
            lookup.Update(ref state);
lookup2.Update(ref state);
lookup3.Update(ref state);
        }

    } 
```

Buffers also work; for ReadOnly, use the ReadOnly attribute from Unity.Collections.