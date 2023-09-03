using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public const int FORCE_CHARACTER_MAX = 10;
    private readonly Vector3 LEADER_LOCAL_FIELD_SCALE = new Vector3(0.5f, 0.5f, 0.5f);
    private readonly Vector3 MEMBER_LOCAL_FIELD_SCALE = new Vector3(0.3f, 0.3f, 0.3f);

    public enum ForceMode
    {
        LocalField,
        Battle
    }

    private List<CharacterBase.CharacterData> _characterDataList = new List<CharacterBase.CharacterData>();
    private List<CharacterBase> _characterList = new List<CharacterBase>();
    public CharacterBase LeaderCharacter { get {  return _characterList[0]; } } 
    private ForceMode _forceMode = ForceMode.LocalField;
    

    public void Create()
    {
        for( int i = 0; i < FORCE_CHARACTER_MAX; i++)
        {
            CharacterBase.CharacterData characterData = new CharacterBase.CharacterData(1);
            _characterDataList.Add(characterData);
        }

        // leader
        CharacterBase character = CharacterLoader.CreateCharacter(_characterDataList[0]);
        character.transform.SetParent(transform);
        _characterList.Add(character);

        for (int i = 1; i < FORCE_CHARACTER_MAX; i++)
        {
            character = CharacterLoader.CreateCharacter(_characterDataList[i]);
            character.transform.SetParent(transform);
            //character.SetLocalPosition( new Vector3((i / 5) * 2 - 1, 0, (i % 5) * 2 - 4 ) );
            //character.transform.localRotation = Quaternion.Euler(0, 270, 0);
            character.CharacterController.radius = 0.2f;
            character.AddAnimationTime(character.GetCurrentAnimationIndex(0), Random.Range(0, 1.0f));
            _characterList.Add(character);
        }

        SetMode(ForceMode.LocalField);
    }

    public void SetMode( ForceMode mode)
    {
        switch (_forceMode)
        {
            case ForceMode.LocalField:
                Vector3 pos = Utility.VECTOR3_ZERO;
                LeaderCharacter.transform.localScale = LEADER_LOCAL_FIELD_SCALE;
                for ( int i = 1; i < FORCE_CHARACTER_MAX; i++ )
                {
                    CharacterBase character = _characterList[i];
                    character.transform.localScale = MEMBER_LOCAL_FIELD_SCALE;
                    pos.x = Utility.Sin(i * 40.0f) * 0.75f;
                    pos.z = Utility.Cos(i * 40.0f) * 0.75f;
                    character.SetLocalPosition(pos);

                }
                break;
        }
    }

    public void SetPos( Vector3 pos )
    {
    }



}
