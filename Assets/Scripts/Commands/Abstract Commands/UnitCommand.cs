using System.Collections;
using UnityEngine;

namespace Command.Player
{
    public abstract class UnitCommand : ICommand
    {
        public CommandData commandData;

        protected UnitController actorUnit;
        protected UnitController targetUnit;

        public abstract void Execute();

        public abstract void Undo();

        public abstract bool WillHitTarget();

        public void SetActorUnit(UnitController actorUnit) => this.actorUnit = actorUnit;

        public void SetTargetUnit(UnitController taregtUnit) => this.targetUnit = taregtUnit;
    }
}