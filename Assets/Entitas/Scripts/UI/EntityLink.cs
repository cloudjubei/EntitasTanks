﻿using UnityEngine;

using Entitas;

public class EntityLink : MonoBehaviour
{
    public Entity entity;
}

public static class EntityLinkExtension
{
    public static bool HasEntity(this GameObject gameObject)
    {
        return gameObject != null && gameObject.GetComponent<EntityLink>() != null;
    }

    public static Entity GetEntity(this GameObject gameObject)
    {
        return gameObject.GetComponent<EntityLink>().entity;
    }

    public static void LinkEntity(this GameObject gameObject, Entity entity)
    {
        gameObject.GetComponent<EntityLink>().entity = entity;
        entity.AddGameObject(gameObject);
    }
}