namespace FirstWorld.Logic
{
    public interface IStarvable
    {
        int FoodStorage { get; set; }
        int FoodConsumption { get; }
    }
}
