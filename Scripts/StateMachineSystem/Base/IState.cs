using System.Net.NetworkInformation;

public interface IState
{
    void Enter();
    void Exit();
    void LogicUpdate();
    void PhysicUpdate();
}
