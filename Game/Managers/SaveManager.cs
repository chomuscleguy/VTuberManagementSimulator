using System.IO;
using System.Text.Json;

namespace VTuberManagementSimulator
{
    public interface ISaveManager
    {
        void SaveGame(int slot, IGameManager game);
        GameSaveData? LoadGameData(int slotIndex);
        SaveSlotPreview GetPreview(int slot);
    }

    public class SaveManager : ISaveManager
    {
        private const string SaveFolder = "Save";

        private string GetSlotPath(int slot)
            => $"{SaveFolder}/slot_{slot}.json";

        public void SaveGame(int slotIndex, IGameManager game)
        {
            Directory.CreateDirectory(SaveFolder);

            var saveData = game.ExtractSave();
            saveData.SavedAt = DateTime.Now;

            var json = JsonSerializer.Serialize(
                saveData,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(GetSlotPath(slotIndex), json);
        }

        public GameSaveData? LoadGameData(int slotIndex)
        {
            var path = GetSlotPath(slotIndex);
            if (!File.Exists(path))
                return null;

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<GameSaveData>(json);
        }

        public bool HasSave(int slotIndex)
        {
            return File.Exists(GetSlotPath(slotIndex));
        }

        public SaveSlotPreview GetPreview(int slot)
        {
            var path = GetSlotPath(slot);
            if (!File.Exists(path))
                return new SaveSlotPreview { SlotIndex = slot, Exists = false };

            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<GameSaveData>(json);

            return new SaveSlotPreview
            {
                SlotIndex = slot,
                Exists = true,
                Day = data?.Day ?? 0,
                SavedAt = data?.SavedAt ?? DateTime.MinValue
            };
        }
    }
}
