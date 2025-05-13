using Command.Actions;
using Command.Main;
using Command.Player;

public class AttackStance : UnitCommand
{
    private bool willHitTarget;

    public AttackStance(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget() => true;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);
}