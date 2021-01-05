using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DefaultProjectInstaller", menuName = "Installers/DefaultProjectInstaller")]
public class DefaultProjectInstaller : ScriptableObjectInstaller<DefaultProjectInstaller>
{
    [SerializeField] GameObject KernelIteratorPrefab;
    public override void InstallBindings()
    {
        Container.Bind<LettersParser>().AsSingle().NonLazy();
        //Container.Bind<SacrificePricesParser>().AsSingle().NonLazy();
        Container.Bind<ShopPricesParser>().AsSingle().NonLazy();

        Container.Bind<KernelParser>().FromComponentInNewPrefab(KernelIteratorPrefab).AsSingle().NonLazy();
    }
}