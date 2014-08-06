# Entity Component System Framework

## Usage

	var engine = new EntityEngine();
	var entity = engine.CreateEntity();
	entity.AddComponent(new MyComponent());
	entity.AddSystem(new MySystem());

	engine.Start();

	// Update engine
	float deltaTime = 16.0f;
	engine.Update(deltaTime);

