# Cấu trúc thư mục
Assets/
├── _Project/                 <-- Thư mục chính của game (có thể đổi theo tên dự án)
│   ├── Domain/               <-- Core logic, không phụ thuộc Unity
│   │   ├── Entities/         <-- Lớp mô tả dữ liệu (Player, Enemy, Item...)
│   │   ├── ValueObjects/     <-- Các kiểu dữ liệu phức hợp (Vector, Stat, ID...)
│   │   ├── Services/         <-- Logic xử lý thuần C# (BattleService, SaveService)
│   │   ├── Interfaces/       <-- Interface (IAudioService, IInputService...)
│   │   └── Repositories/     <-- Interface truy cập dữ liệu (ISaveRepository...)
│   │
│   ├── Application/          <-- Luồng xử lý chính (use case)
│   │   ├── UseCases/         <-- Các hành động chính: Attack, SaveGame, LoadLevel...
│   │   └── DTOs/             <-- Cấu trúc dữ liệu truyền giữa tầng
│   │
│   ├── Infrastructure/       <-- Phần “nối” Unity và Domain
│   │   ├── Input/            <-- Triển khai IInputService (UnityInputService)
│   │   ├── Audio/            <-- Triển khai IAudioService
│   │   ├── Persistence/      <-- Lưu dữ liệu, ví dụ PlayerPrefs, JSON, Database
│   │   ├── UI/               <-- View logic, UI Controller, Canvas logic
│   │   ├── Adapters/         <-- Code “chuyển đổi” giữa Domain <-> Unity objects
│   │   ├── Factories/        <-- Sinh object (spawn Player, Enemy,...)
│   │   ├── Installers/       <-- Zenject/Dependency Injector (nếu dùng)
│   │   └── Managers/         <-- GameManager, SceneManager, AudioManager, ...
│   │
│   ├── Presentation/         <-- Phần hiển thị và Unity scene
│   │   ├── Scenes/           <-- Tất cả các Scene
│   │   ├── Prefabs/          <-- Prefab cho UI, nhân vật, hiệu ứng
│   │   ├── UI/               <-- Layout UGUI, Canvas, Elements
│   │   ├── Animations/       <-- Animation clips, controllers
│   │   ├── Materials/        <-- Materials
│   │   ├── Sprites/          <-- Hình ảnh 2D
│   │   ├── Models/           <-- Model 3D (FBX, OBJ)
│   │   ├── Audio/            <-- Âm thanh, nhạc nền
│   │   ├── Effects/          <-- Particle system, VFX
│   │   └── Fonts/            <-- Phông chữ
│   │
│   ├── Data/                 <-- Dữ liệu cấu hình game
│   │   ├── ScriptableObjects/  <-- Config gameplay (ItemData, EnemyData, LevelData)
│   │   ├── Localization/       <-- File ngôn ngữ (CSV, JSON)
│   │   ├── Settings/           <-- Global setting (audio, resolution, difficulty)
│   │   └── SaveData/           <-- Dữ liệu người chơi (tự sinh hoặc test)
│   │
│   ├── Tests/                <-- Unit test, integration test
│   │   ├── DomainTests/
│   │   └── ApplicationTests/
│   │
│   ├── Utilities/            <-- Helper, extension methods, constants
│   └── README.md
│
└── Plugins/                  <-- Thư viện bên thứ 3 (DOTween, Zenject, TextMeshPro...)


## Tóm lại cho gọn:
| Nhóm               | Chức năng                  | Mô tả                                              |
| ------------------ | -------------------------- | -------------------------------------------------- |
| **Domain**         | Core logic                 | Chứa toàn bộ business rule, không phụ thuộc Unity  |
| **Application**    | Dòng chảy hành động        | Định nghĩa các use case cụ thể                     |
| **Infrastructure** | Liên kết Unity & logic     | Chứa code phụ thuộc Unity (Audio, Input, Save, UI) |
| **Presentation**   | Hiển thị                   | Scene, Prefab, UI, Asset, VFX, Audio               |
| **Data**           | Cấu hình & dữ liệu runtime | Các ScriptableObject, JSON, hoặc file lưu          |
| **Bootstrap**      | Entry point                | Code khởi tạo hệ thống khi vào scene đầu tiên      |
| **Utilities**      | Tiện ích dùng chung        | Static class, extension, helper                    |
| **Tests**          | Kiểm thử                   | Test độc lập logic của Domain, Application         |
| **Plugins**        | Thư viện bên ngoài         | DOTween, Odin, Zenject, v.v.                       |

## Nguyên tắc quản lý
1. Không cho Domain “nhìn thấy” Unity
→ Không dùng MonoBehaviour, GameObject, Transform, Debug.Log trong Domain.

2. Infrastructure là cầu nối
→ Dùng IAudioService, IInputService, ISaveRepository để domain không phụ thuộc engine.

3. ScriptableObject = data, không logic
→ Chỉ lưu config, không xử lý behavior.

4. Prefab/UI/Scene = view layer
→ Không chứa logic phức tạp, chỉ gọi đến Application hoặc Domain thông qua Service.